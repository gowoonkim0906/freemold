using Freemold.Modules.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ImageMagick;
using System.Threading.Channels;

namespace Freemold.Modules.Services
{
    public class FileService : IFileService
    {
        private readonly string _root;
        private IHostEnvironment _env;

        public FileService(IOptions<StorageOptions> opts, IHostEnvironment env) {

            var raw = opts.Value.RootPath;
            /*_root = Path.GetFullPath(string.IsNullOrWhiteSpace(raw)
                ? Path.Combine(env.ContentRootPath, "Data")   // 폴백
                : raw);*/

            _root = string.IsNullOrWhiteSpace(raw)
            ? Path.Combine(env.ContentRootPath, "Data")   // 폴백
            : raw;

            Directory.CreateDirectory(_root); // 경로 보장

            _env = env;
        }


        public string RootPath => _root;

        public string WebRoot => Path.Combine(_env.ContentRootPath, "wwwroot");


        public async Task SaveWithWatermarkAsync(
            IFormFile inputFile,
            Stream outStream,
            string logoPath,
            string originalExt,
            double opacity = 0.35,  // 배경 워터마크는 0.10~0.25 정도 권장
            double _scaleIgnored = 0.0, // (COVER 모드에선 미사용)
            int? _padIgnored = null // (COVER 모드에선 미사용)
        )
        {
            // 1) 입력 로드
            using var inMs = new MemoryStream();
            await inputFile.CopyToAsync(inMs);
            inMs.Position = 0;

            using var image = new MagickImage(inMs, new MagickReadSettings { ColorSpace = ColorSpace.sRGB });
            image.AutoOrient();
            image.Strip();

            // 2) 로고 로드 (투명 PNG 권장)
            using var logo = new MagickImage(logoPath);
            logo.Alpha(AlphaOption.On);

            // (선택) 로고가 흰 배경이면 흰색을 투명화 (완벽하진 않음)
            try
            {
                logo.ColorFuzz = new Percentage(10); // 허용 오차
                logo.Transparent(MagickColors.White);
            }
            catch { /* 버전 미지원 시 무시 */ }

            // 3) COVER 스케일 계산: 이미지 전체를 덮도록
            int iw = unchecked((int)image.Width);
            int ih = unchecked((int)image.Height);
            int lw = unchecked((int)logo.Width);
            int lh = unchecked((int)logo.Height);

            double scaleCover = Math.Max(iw / (double)lw, ih / (double)lh);
            int coverW = Math.Max(1, (int)Math.Round(lw * scaleCover));
            int coverH = Math.Max(1, (int)Math.Round(lh * scaleCover));

            uint coverWu = (uint)Math.Max(1, coverW);
            uint coverHu = (uint)Math.Max(1, coverH);

            // 4) 로고 리사이즈(비율 유지, 꽉 채우기)
            var geo = new MagickGeometry(coverWu, coverHu) { IgnoreAspectRatio = true };
            logo.Resize(geo);

            // 5) 배경 워터마크 투명도(더 옅게 권장)
            double alpha = Math.Clamp(opacity, 0.05, 0.40);
            logo.Evaluate(Channels.Alpha, EvaluateOperator.Multiply, alpha);

            // 6) 중앙에 합성(배경처럼)
            image.Composite(logo, Gravity.Center, 0, 0, CompositeOperator.Over);

            // 7) 출력 포맷 결정
            var ext = (originalExt ?? "").ToLowerInvariant();
            (MagickFormat fmt, uint qualityU) = ext switch
            {
                "png" => (MagickFormat.Png, 0u),
                "webp" => (MagickFormat.WebP, 82u),
                _ => (MagickFormat.Jpeg, 82u),
            };

            if (fmt == MagickFormat.Jpeg)
            {
                // 일부 버전에선 uint만 허용 → uint로 고정
                image.Quality = Math.Clamp(qualityU, 1u, 100u);
                // (진행형/샘플링 등은 네 빌드에서 API가 없을 수 있어 생략)
            }

            // 8) 저장
            image.Write(outStream, fmt);
            await outStream.FlushAsync();
        }


        public async Task SaveWithWatermarkAsync2(
            IFormFile inputFile,
            Stream outStream,
            string logoPath,
            string originalExt,
            double opacity = 0.30,   // 더 진하게 (0.6~0.85 권장)
            double tileScale = 0.20, // 기본: 짧은 변의 40% (크게 보이도록)
            int? gapPx = null        // 이번 버전에서는 overlap 우선, gap은 미사용
        )
        {
            using var inMs = new MemoryStream();
            await inputFile.CopyToAsync(inMs);
            inMs.Position = 0;

            using var image = new MagickImage(inMs, new MagickReadSettings { ColorSpace = ColorSpace.sRGB });
            image.AutoOrient();
            image.Strip();

            using var logo = new MagickImage(logoPath);
            logo.Alpha(AlphaOption.On);

            int iw = unchecked((int)image.Width);
            int ih = unchecked((int)image.Height);

            // ===== 1) 타일 크기: 짧은 변 기준 + 최소 픽셀 보장 =====
            int baseSide = Math.Min(iw, ih);                           // 짧은 변 기준이 체감상 안정적
            double scaleFactor = Math.Max(0.04, tileScale);            // 상한 제거(원하는 만큼 키울 수 있게)
            int tileLong = Math.Max(500, (int)Math.Round(baseSide * scaleFactor)); // 최소 700px 보장

            int lw0 = unchecked((int)logo.Width);
            int lh0 = unchecked((int)logo.Height);
            bool wide = lw0 >= lh0;

            int tileW = wide ? tileLong : Math.Max(1, (int)Math.Round(tileLong * (lw0 / (double)lh0)));
            int tileH = wide ? Math.Max(1, (int)Math.Round(tileLong * (lh0 / (double)lw0))) : tileLong;

            uint tileWu = (uint)Math.Max(1, tileW);
            uint tileHu = (uint)Math.Max(1, tileH);

            using var tile = (MagickImage)logo.Clone();
            tile.Resize(tileWu, tileHu);

            // ===== 2) 불투명도(진하게) & 색상 유지 =====
            double a = Math.Clamp(opacity, 0.05, 1.0); // 5%~100%
            tile.Evaluate(Channels.Alpha, EvaluateOperator.Multiply, a);
            // 흐릿해지는 Modulate(채도 0) 제거
            // tile.Modulate(new Percentage(100), new Percentage(100), new Percentage(100));

            // ===== 3) 캔버스 준비 =====
            var rs = new MagickReadSettings
            {
                Width = (uint)iw,
                Height = (uint)ih,
                BackgroundColor = MagickColors.Transparent
            };
            using var tiled = new MagickImage();
            tiled.Read("canvas:none", rs);
            tiled.Alpha(AlphaOption.Set);

            // ===== 4) 회전(선택) =====
            int rotateDeg = 0; // 10~15 정도 주면 패턴 티 감소 + 더 꽉 차 보임
            if (rotateDeg != 0)
            {
                tile.Rotate(rotateDeg);
                tileW = (int)tile.Width;
                tileH = (int)tile.Height;
            }

            // ===== 5) 겹치기 기반 스텝 계산 (촘촘함의 핵심) =====
            // overlap: 0.45 => 45% 겹침, 값이 클수록 더 촘촘
            double overlap = 0.50; // 0.35~0.65 권장. 아주 촘촘하게는 0.55~0.65
            int stepX = Math.Max(1, (int)Math.Round(tileW * (1.0 - overlap)));
            int stepY = Math.Max(1, (int)Math.Round(tileH * (1.0 - overlap)));

            // ===== 6) 오버타일링 + 2-패스(반 스텝 쉬프트) =====
            int baseOffX = -tileW / 2; // 음수 시작: 테두리 빈틈 방지
            int baseOffY = -tileH / 2;

            void Paint(int offsetX, int offsetY)
            {
                for (int y = offsetY, row = 0; y < ih + tileH; y += stepY, row++)
                {
                    int startX = offsetX + ((row % 2 == 0) ? 0 : stepX / 2); // 지그재그(벌집 느낌)
                    for (int x = startX; x < iw + tileW; x += stepX)
                        tiled.Composite(tile, x, y, CompositeOperator.Over);
                }
            }

            // 1패스: 기본
            Paint(baseOffX, baseOffY);
            // 2패스: 반 스텝 쉬프트(빈칸을 메움)
            Paint(baseOffX + stepX / 2, baseOffY + stepY / 2);

            image.Composite(tiled, Gravity.Northwest, 0, 0, CompositeOperator.Over);

            // ===== 7) 인코딩 =====
            var ext = (originalExt ?? "").ToLowerInvariant();
            (MagickFormat fmt, uint qualityU) = ext switch
            {
                "png" => (MagickFormat.Png, 0u),
                "webp" => (MagickFormat.WebP, 90u),
                _ => (MagickFormat.Jpeg, 90u),
            };

            if (fmt == MagickFormat.Jpeg)
                image.Quality = Math.Clamp(qualityU, 1u, 100u);

            image.Write(outStream, fmt);
            await outStream.FlushAsync();
        }
    }
}

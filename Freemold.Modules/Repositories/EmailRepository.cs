using Freemold.Modules.Common;

namespace Freemold.Modules.Repositories
{
    public class EmailRepository : BaseRepository
    {
        public EmailRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        { }

        public async Task<string> EmailSendInsert(TB_EMAIL_SEND input, CancellationToken ct = default)
        {
            try
            {

                var entity = new TB_EMAIL_SEND
                {
                    ToEmail = input.ToEmail,
                    FromEmail = input.FromEmail,
                    EmailSubject = input.EmailSubject,
                    EmailState = input.EmailState,
                    SendDate = DateTime.Now,
                    RegIp = input.RegIp
                };

                await _appdbcontext.TB_EMAIL_SEND.AddAsync(entity, ct);
                var rows = await _appdbcontext.SaveChangesAsync(ct);

                return rows > 0 ? "success" : "fail";
            }
            catch (Exception ex)
            {
                _appdbcontext.ChangeTracker.Clear();
                return "fail";
            }

        }
    }
}

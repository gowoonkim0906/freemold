using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;

namespace Freemold.Modules.Services
{
    public class EmailService : IEmailService
    {
        private readonly GmailService _gmailService;

        public EmailService(string contentRootPath)
        {
            var credentialFile = Path.Combine(contentRootPath, "credentials.json");
            UserCredential credential;

            using (var stream = new FileStream(credentialFile, FileMode.Open, FileAccess.Read))
            {
                string credPath = Path.Combine(contentRootPath, "token.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { "https://www.googleapis.com/auth/gmail.send" },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            _gmailService = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Gmail API Send Mail"
            });
        }

        public void SendEmail(string from, string to, string subject, string body)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(from, from));
            mimeMessage.To.Add(new MailboxAddress(to, to));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("html") { Text = body };

            using (var stream = new MemoryStream())
            {
                mimeMessage.WriteTo(stream);
                var rawMessage = Convert.ToBase64String(stream.ToArray())
                    .Replace("+", "-").Replace("/", "_").Replace("=", "");

                var message = new Message { Raw = rawMessage };

                _gmailService.Users.Messages.Send(message, "me").Execute();
            }
        }

    }
}

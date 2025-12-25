using MimeKit;
using MailKit.Security;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

public static class EmailService
{
    // TODO: cấu hình theo tài khoản SMTP của bạn
    private const string SmtpHost = "smtp.gmail.com";
    private const int SmtpPort = 587;

    private const string FromEmail = "yourgmail@gmail.com";
    private const string AppPassword = "YOUR_GMAIL_APP_PASSWORD"; // App Password (không phải mật khẩu thường)

    public static async Task SendAsync(string toEmail, string subject, string body, string attachmentPath)
    {
        var message = new MimeMessage();
        message.From.Add(MailboxAddress.Parse(FromEmail));
        message.To.Add(MailboxAddress.Parse(toEmail));
        message.Subject = subject;

        var builder = new BodyBuilder { TextBody = body };
        builder.Attachments.Add(attachmentPath);
        message.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(SmtpHost, SmtpPort, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(FromEmail, AppPassword);
        await smtp.SendAsync(message);
        await smtp.DisconnectAsync(true);
    }
}

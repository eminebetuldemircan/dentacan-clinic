using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Net;
using System.Net.Mail;

public static class EmailHelper
{
    // Gmail hesabı bilgilerini buraya girin
    private static string smtpServer = "smtp.gmail.com";
    private static int smtpPort = 587;
    private static string fromEmail = "eminebetuldemircan@gmail.com"; // Gmail adresin
    private static string fromPassword = "iqkj olrm kcah kall"; // Yukarıda aldığın uygulama şifresi

    public static string SendVerificationCode(string toEmail, string verificationCode,int appointmentId,string description)
    {

        try
        {
            using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            {
                client.Credentials = new NetworkCredential(fromEmail, fromPassword);
                client.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = "Doğrulama Kodu";
                string verificationLink = $"http://localhost:3000/verify?code={verificationCode}&appointmentId={appointmentId}";
                string cacelationLink = $"http://localhost:3000/cancel?appointmentId={appointmentId}";
                mail.Body = $"Merhaba,\n\n" +
                    description +"\n\n" +
                    $" Doğrulama kodunuz: {verificationCode}\n\n" +
                            $"Aşağıdaki bağlantıya tıklayarak doğrulama işlemini tamamlayabilirsiniz:\n{verificationLink}\n\n"+
                            $"Aşağıdaki bağlantıya tıklayarak iptal yapabilirsiniz:\n{cacelationLink}";

                client.Send(mail);
                Console.WriteLine("Doğrulama kodu başarıyla gönderildi.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Mail gönderme hatası: " + ex.Message);
            return null;
        }

        return verificationCode; // Kod doğrulama için döndürülür
    }
    public static bool SendChangeToken(string toEmail, string token, string description)
    {

        try
        {
            using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            {
                client.Credentials = new NetworkCredential(fromEmail, fromPassword);
                client.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = "Randevu Değiştirme";
                string changeappointmentLink = $"http://localhost:3000/changeappointment?token={token}";

                mail.Body = $"Merhaba, "+
                    description + "\n\n" +
                    $"Randevunuzu değiştirmek için tıklayınız: {changeappointmentLink}\n\n";

                client.Send(mail);
                Console.WriteLine("Randevu değiştirme başarıyla gönderildi.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Mail gönderme hatası: " + ex.Message);
            return false;
        }

        return true; // Kod doğrulama için döndürülür
    }




}

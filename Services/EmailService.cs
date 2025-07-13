using MailKit.Net.Smtp;
using MimeKit;

public static class EmailService
{
    public static async Task SendMessage(MessageModel Message)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Altawbah", "altawbah.voyages@gmail.com"));
        message.To.Add(new MailboxAddress("Altawbah", "altawbah.voyages@gmail.com"));
        message.Subject = "message from client";

        var bodyBuilder = new BodyBuilder
        {
            TextBody = $" name : {Message.Name}\n email : {Message.Email}\n message : {Message.Message}"
        };

        message.Body = bodyBuilder.ToMessageBody();

        // إعداد SMTP
        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.gmail.com", 587, false);
        await client.AuthenticateAsync("altawbah.voyages@gmail.com", "wnyb yxhz fgwj qrno");
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
    public static async Task SendReservation(ReservationModel reservation)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Altawbah", "altawbah.voyages@gmail.com"));
        message.To.Add(new MailboxAddress("Altawbah", "altawbah.voyages@gmail.com"));
        message.Subject = "reservation message";

        List<string> persones = new List<string>();

        for (var i = 0; i < reservation.Persons.Count; ++i)
        {
            persones.Add($" Person {i+1} : \n first name : {reservation.Persons[i].FirstName}\n last name : {reservation.Persons[i].LastName}\n  born date : {reservation.Persons[i].BornDate}\n  passeport number : {reservation.Persons[i].PasseportNumber}\n  passeport exp : {reservation.Persons[i].PasseportExperationDate}\n");
        }

        string personesString = string.Join("", persones);

        var bodyBuilder = new BodyBuilder
        {
            TextBody = $" type : {reservation.PackageType}\n email : {reservation.Email}\n phone : {reservation.PhoneNumber}\n train : {reservation.TrainBooking}\n wheel chair pusher : {reservation.WheelChairPusher}\n notes : {reservation.Notes}\n {personesString}"
        };


        for (var i = 0; i < reservation.Persons.Count; ++i)
        {
            if (reservation.Persons[i].Passeport != null)
            {
                using var ms = new MemoryStream();
                await reservation.Persons[i].Passeport.CopyToAsync(ms);
                bodyBuilder.Attachments.Add(reservation.Persons[i].Passeport.FileName, ms.ToArray());
            }
        }
        message.Body = bodyBuilder.ToMessageBody();

        // إعداد SMTP
        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.gmail.com", 587, false);
        await client.AuthenticateAsync("altawbah.voyages@gmail.com", "wnyb yxhz fgwj qrno");
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
    public static async Task SendSubscribe(string email)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Altawbah", "altawbah.voyages@gmail.com"));
        message.To.Add(new MailboxAddress("Altawbah", "altawbah.voyages@gmail.com"));
        message.Subject = "subscribtion message";

        var bodyBuilder = new BodyBuilder
        {
            TextBody = $" email : {email}"
        };

        message.Body = bodyBuilder.ToMessageBody();

        // إعداد SMTP
        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.gmail.com", 587, false);
        await client.AuthenticateAsync("altawbah.voyages@gmail.com", "wnyb yxhz fgwj qrno");
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    } 
}
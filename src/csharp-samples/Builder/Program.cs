using System;
using System.Text;
using System.Net.Mail;

// ReSharper disable All

namespace Builder
{
    public static class Program
    {
        public static void Main()
        {
            MailMessage mail1 = new MailMessageBuilder()
                .From("test@mail.ru")
                .To("test@mail.ru")
                .Cc("test@mail.ru")
                .Subject("Test 2")
                .Body("Test 2", Encoding.UTF8)
                .Build();

            MailMessage mail2 = new MailMessage()
                .From("test@mail.ru")
                .To("test@mail.ru")
                .Cc("test@mail.ru")
                .Subject("Test 2")
                .Body("Test 2", Encoding.UTF8);

            SmtpClient client = new SmtpClient();

            client.Send(mail1);

            client.Send(mail2);

            Console.ReadKey();
        }
    }

    public sealed class MailMessageBuilder
    {
        private readonly MailMessage _message;

        public MailMessageBuilder()
        {
            _message = new MailMessage();
        }

        public MailMessageBuilder From(string address)
        {
            _message.From = new MailAddress(address);

            return this;
        }

        public MailMessageBuilder To(string address)
        {
            _message.To.Add(address);

            return this;
        }

        public MailMessageBuilder Cc(string address)
        {
            _message.CC.Add(address);

            return this;
        }

        public MailMessageBuilder Subject(string subject)
        {
            _message.Subject = subject;

            return this;
        }

        public MailMessageBuilder Body(string body, Encoding encoding)
        {
            _message.Body = body;
            _message.BodyEncoding = encoding;

            return this;
        }

        public MailMessage Build()
        {
            return _message;
        }
    }

    public static class MailMessageBuilderExtensions
    {
        public static MailMessage From(this MailMessage message, string address)
        {
            message.From = new MailAddress(address);

            return message;
        }

        public static MailMessage To(this MailMessage message, string address)
        {
            message.To.Add(address);

            return message;
        }

        public static MailMessage Cc(this MailMessage message, string address)
        {
            message.CC.Add(address);

            return message;
        }

        public static MailMessage Subject(this MailMessage message, string subject)
        {
            message.Subject = subject;

            return message;
        }

        public static MailMessage Body(this MailMessage message, string body, Encoding encoding)
        {
            message.Body = body;
            message.BodyEncoding = encoding;

            return message;
        }
    }
}

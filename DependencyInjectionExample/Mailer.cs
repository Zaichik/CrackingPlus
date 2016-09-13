namespace DependencyInjectionExample
{
    public class Mailer : IMailer
    {
        public string FromAddress { get; set; }
        public string SmtpServer { get; set; }
    }
}
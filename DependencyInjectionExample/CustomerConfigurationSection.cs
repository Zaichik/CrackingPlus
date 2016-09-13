using System.Configuration;
using System.Runtime.Remoting.Channels;

namespace DependencyInjectionExample
{
    public class CustomerConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("mailer", IsRequired = true)]
        public MailerElement Mailer
        {
            get { return (MailerElement) base["mailer"]; } 
            set { base["mailer"] = value; }
        }
    }

    public class ProviderTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string) base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string) base["type"]; } 
            set { base["type"] = value; }
        }
    }

    public class PaymentProcessorElement : ProviderTypeElement
    {
    }

    public class MailerElement : ProviderTypeElement
    {
        [ConfigurationProperty("fromAddress", IsRequired = true)]
        public string FromAddress
        {
            get { return (string) base["fromAddress"]; } 
            set { base["fromAddress"] = value; }
            
        }

        [ConfigurationProperty("smtpServer", IsRequired = true)]
        public string SmtpServer
        {
            get { return (string) base["smtpServer"]; }
            set { base["smtpServer"] = value; }
            
        }
    }
}
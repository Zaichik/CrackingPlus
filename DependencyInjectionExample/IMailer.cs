using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    interface IMailer
    {
        string FromAddress { get; set; }
        string SmtpServer { get; set; }

    }
}

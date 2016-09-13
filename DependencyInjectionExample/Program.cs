using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;


namespace DependencyInjectionExample
{
    class Program
    {
        //UI
        static void Main(string[] args)
        {
            IUnityContainer objContainer = new UnityContainer();
            //objContainer.LoadConfiguration();

            objContainer.RegisterType<Customer>()
                        .RegisterType<IDal, SqlServerDal>();
            //objContainer.RegisterType<IDal, OracleDal>();
            Customer obj = objContainer.Resolve<Customer>();
            obj.CustomerName = "test1";
            obj.Add();

        }
    }

    // Middle layer
    public class Customer
    {
        private IDal Odal;
        public string CustomerName { get; set; }
        IMailer _Mailer;

        public Customer(IDal iobj)
        {
            Odal = iobj;

            CustomerConfigurationSection config = ConfigurationManager.GetSection("commerceEngine") as CustomerConfigurationSection;
            if (config != null)
            {
                _Mailer = Activator.CreateInstance(Type.GetType(config.Mailer.Type)) as IMailer;
                _Mailer.FromAddress = config.Mailer.FromAddress;
                _Mailer.SmtpServer = config.Mailer.SmtpServer;
            }
        }
        public void Add()
        {
            Odal.Add();
        }
    }

    public interface IDal
    {
        void Add();
    }

    // DAL
    public class SqlServerDal:IDal
    {
        public void Add()
        {
            Console.WriteLine("Sql Server inserted");
        }
    }

    public class OracleDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("Oracle Server inserted");
        }
    }

}

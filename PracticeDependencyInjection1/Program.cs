using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
//using Microsoft.Practices.Unity.

namespace PracticeDependencyInjection1
{
    // UI
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer objContainer = new UnityContainer();
            objContainer.RegisterType<Customer>();
            objContainer.RegisterType<IDal, OracleDal>();
            objContainer.RegisterType<IDal, SqlServerDal>();

            var cust = objContainer.Resolve<Customer>();
            cust.Name = "test";
            cust.Add();
        }
    }
}

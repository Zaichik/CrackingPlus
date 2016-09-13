using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDependencyInjection1
{
    // BL
    public class Customer
    {
        public string Name { get; set; }
        private IDal Dal { get; set; }

        public Customer(IDal iDal)
        {
            Dal = iDal;
        }

        public void Add()
        {
            Dal.Add();
        }
    }
}

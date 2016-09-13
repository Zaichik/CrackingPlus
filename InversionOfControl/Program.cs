using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Customer
    {
        private SqlServerDal dal;

        public bool Validate()
        {
            return true;
        }

        public void Add()
        {
            if (Validate()) dal.Add();
        }
    }

    public class SqlServerDal
    {
        public void Add()
        {
            Console.WriteLine("OracleDal");
        }

    }
}

using System;

namespace PracticeDependencyInjection1
{
    public class SqlServerDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("OracleDal");
        }
    }
}
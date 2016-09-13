using System;

namespace PracticeDependencyInjection1
{
    public class OracleDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("OracleDal");
        }
    }
}
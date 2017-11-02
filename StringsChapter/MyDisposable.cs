using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsChapter
{
    class MyDisposable:IDisposable
    {
        private MyDisposable()
        {
            Console.WriteLine("ctor");
            //throw new Exception();
        }

        public static MyDisposable Create()
        {
            //return null;
            return new MyDisposable();
        }

        public void MyMethod()
        {
            Console.WriteLine("MyMethod");
            throw new Exception();
        }

        public void Dispose()
        {
            Console.WriteLine("dispose");
        }
    }
}

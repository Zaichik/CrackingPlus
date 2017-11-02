using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole
{
    class Car : IDisposable
    {
        private FileStream fileStream;

        public Car()
        {
            try
            {
                Console.WriteLine("Car ctor called");
                fileStream = new FileStream($"C:\\temp\\MyTestFile.txt", FileMode.OpenOrCreate);
                //throw new Exception("Car ctor exception"); // Dispose will not be called from here, therefore need to clean up in the catch.
                int blah = 2;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                //Dispose();
                if (fileStream != null) fileStream.Dispose(); // clean up directly instead of calling Dispose()
                throw;
            }
        }

        public void Drive(int miles)
        {
            Console.WriteLine("Drive called.");
            byte[] text = Encoding.ASCII.GetBytes($"Driving {miles} miles.");
            fileStream.Write(text, 0, text.Length);
            throw new Exception("Drive: Hello exception");
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose called.");
            throw new Exception("Dispose: Exception. Really??!"); // when called within using{} without try/catch, this will mask the Hello exception in Drive().
            if (fileStream != null) fileStream.Dispose();
        }
    }
}

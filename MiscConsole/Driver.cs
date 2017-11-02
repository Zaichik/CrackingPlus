using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole
{
    class Driver
    {
        public Driver()
        {
            try
            {
                try
                {
                    using (Car car = new Car())
                    {
                        try
                        {
                            car.Drive(5);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                            throw;
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine();
                    Console.WriteLine(" ---Caught EXCEPTION: " + exception);
                    throw exception; // Generally, not a good idea - it resets the stack to this line.
                    //---Caught EXCEPTION: System.Exception: Dispose: Exception.Really ?? !
                    //        at MiscConsole.Car.Dispose() in C:\RD\Training\CrackingPlus\MiscConsole\Car.c
                    //s:line 42
                    //at MiscConsole.Driver..ctor() in C:\RD\Training\CrackingPlus\MiscConsole\Driv
                    //er.cs:line 28
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine();
                Console.WriteLine(" ---Caught THROW EXCEPTION: " + exception);
                //---Caught THROW EXCEPTION: System.Exception: Dispose: Exception.Really ?? !
                //        at MiscConsole.Driver..ctor() in C:\RD\Training\CrackingPlus\MiscConsole\Driv
                //er.cs:line 34
            }
        }
    }
}

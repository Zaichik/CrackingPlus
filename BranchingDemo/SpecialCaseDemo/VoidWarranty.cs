using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo.SpecialCaseDemo
{
    // Null Object - an object which exposes a certain interface, but internally it does nothing.
    // Use it as a substitute instead of null.
    class VoidWarranty : IWarranty
    {
        [ThreadStatic] // ensures that every thread will see a separate instance of the object, therefore no need for locking when new obj is instantiated.
        private static VoidWarranty instance;
        private VoidWarranty(){}

        public static VoidWarranty Instance
        {
            get
            {
                if(instance == null)
                    instance = new VoidWarranty();
                return instance;
            }
        }
        public bool IsValidOn(DateTime date) => false;
    }
}

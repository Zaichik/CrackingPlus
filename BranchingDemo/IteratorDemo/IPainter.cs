using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo.IteratorDemo
{
    public interface IPainter
    {
        bool IsAvailable { get; }

        TimeSpan EstimateTimeToPaint(double sqMeters);

        double EstimateCompensation(double sqMeters);
    }
}

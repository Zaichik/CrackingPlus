using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo.IteratorDemo
{
    public static class FindPainter
    {
        public static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                    painters
                            //.ThoseAvailable()
                            .Where(painter => painter.IsAvailable)
                            //.WithMinimum(painters.EstimateCompensation(sqMeters));
                            //.Aggregate((best, cur) => 
                            //    best.EstimateCompensation(sqMeters) < cur.EstimateCompensation(sqMeters) ? 
                            //    best : cur);
                            .WithMinimum(painter => painter.EstimateCompensation(sqMeters));
        }
        public static IPainter FindFastestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                    painters
                            .Where(painter => painter.IsAvailable)
                            .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
        }
        public static void WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time =
                    TimeSpan.FromHours(1 /
                                       painters
                                               .Where(painter => painter.IsAvailable)
                                               .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters)
                                                                          .TotalHours)
                                               .Sum());
        }
    }
}

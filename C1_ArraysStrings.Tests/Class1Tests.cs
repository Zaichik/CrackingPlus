using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1_3_RemoveDupChars;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace C1_3_RemoveDupChars.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void RemoveDuplicateCharTest_no_dups()
        {
            string str = "abcd";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            char[] charStr = str.ToCharArray();
            Class1.RemoveDuplicateChar(charStr);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Assert.AreEqual(str, charStr.ToString());
        }
    }
}

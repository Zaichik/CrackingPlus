using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1_ArraysStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace C1_ArraysStrings.Tests
{
    [TestClass()]
    public class IsUniqueCharString1Tests
    {

        #region where_abcdb_return_not_unique
        [TestMethod()]
        public void IsUniqueCharString_ASCIITest_where_abcdb_return_not_unique()
        {
            Assert.IsFalse(IsUniqueCharString1.IsUniqueCharString_ASCII("abcdc"));
        }

        [TestMethod()]
        public void IsUniqueCharString_BitVectorTest_where_abcdb_return_not_unique()
        {
            Assert.IsFalse(IsUniqueCharString1.IsUniqueCharString_BitVector("abcdc"));
        }

        [TestMethod()]
        public void IsUniqueCharString_CheckEveryCharTest_where_abcdb_return_not_unique()
        {
            Assert.IsFalse(IsUniqueCharString1.IsUniqueCharString_CheckEveryChar("abcdc"));
        }

        [TestMethod()]
        public void IsUniqueCharString_DestroySortAllowed2Test_where_abcdc_return_unique()
        {
            Assert.IsFalse(IsUniqueCharString1.IsUniqueCharString_CheckEveryChar("abcdc"));
        }

        #endregion where_abcdb_return_not_unique

        #region where_abcd_return_unique
        [TestMethod()]
        public void IsUniqueCharString_ASCIITest_where_abcd_return_unique()
        {
            Assert.IsTrue(IsUniqueCharString1.IsUniqueCharString_ASCII("abcd"));
        }

        [TestMethod()]
        public void IsUniqueCharString_BitVectorTest_where_abcd_return_unique()
        {
            Assert.IsTrue(IsUniqueCharString1.IsUniqueCharString_BitVector("abcd"));
        }

        [TestMethod()]
        public void IsUniqueCharString_CheckEveryCharTest_where_abcd_return_unique()
        {
            Assert.IsTrue(IsUniqueCharString1.IsUniqueCharString_CheckEveryChar("abcd"));
        }

        [TestMethod()]
        public void IsUniqueCharString_DestroySortAllowed2Test_where_abcd_return_unique()
        {
            Assert.IsTrue(IsUniqueCharString1.IsUniqueCharString_CheckEveryChar("abcd"));
        }

        #endregion where_abcd_return_unique

        #region where_abcdB_return_not_unique
        [TestMethod()]
        public void IsUniqueCharString_ASCIITest_where_abcdB_return_unique()
        {
            Assert.IsTrue(IsUniqueCharString1.IsUniqueCharString_ASCII("abcdB"));
        }

        [TestMethod()]
        public void IsUniqueCharString_BitVectorTest_where_abcdB_return_unique()
        {
            Assert.IsTrue(IsUniqueCharString1.IsUniqueCharString_BitVector("zabcdB"));
        }

        [TestMethod()]
        public void IsUniqueCharString_CheckEveryCharTest_where_abcdB_return_unique()
        {
            Assert.IsTrue(IsUniqueCharString1.IsUniqueCharString_CheckEveryChar("abcdB"));
        }

        [TestMethod()]
        public void IsUniqueCharString_DestroySortAllowed2Test_where_abcdB_return_unique()
        {
            Assert.IsTrue(IsUniqueCharString1.IsUniqueCharString_CheckEveryChar("abcdB"));
        }

        #endregion where_abcdB_return_not_unique

        #region where_abcdb_return_not_unique
        [TestMethod()]
        public void IsUniqueCharString_ASCIITest_where_ab123_return_not_unique()
        {
            Assert.IsFalse(IsUniqueCharString1.IsUniqueCharString_ASCII(testStr1));
        }

        [TestMethod()]
        public void IsUniqueCharString_BitVectorTest_where_ab123_return_not_unique()
        {
            Assert.IsFalse(IsUniqueCharString1.IsUniqueCharString_BitVector(testStr1));
        }

        [TestMethod()]
        public void IsUniqueCharString_CheckEveryCharTest_where_ab123_return_not_unique()
        {
            Assert.IsFalse(IsUniqueCharString1.IsUniqueCharString_CheckEveryChar(testStr1));
        }

        [TestMethod()]
        public void IsUniqueCharString_DestroySortAllowed2Test_where_ab123_return_unique()
        {
            Assert.IsFalse(IsUniqueCharString1.IsUniqueCharString_CheckEveryChar(testStr1));
        }

        #endregion where_abcdb_return_not_unique

        public string testStr1 = "ab!#$%@123";
    }
}

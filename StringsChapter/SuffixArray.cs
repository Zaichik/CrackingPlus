using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsChapter
{
    public class SuffixArray
    {
        public static int[] SortCharacters(string s)
        {
            int[] order = new int[s.Length];
            int[] count = new int[130];
            foreach (char t in s)
                count[t]++;

            for (int j = 1; j < count.Length; j++)
                count[j] = count[j] + count[j - 1];

            for (int i = s.Length - 1; i > 0; i--)
            {
                var c = s[i];
                count[c] = count[c] - 1;
                order[count[c]] = i;
            }

            //string mytest = "testing";
            //test(mytest);

            //try
            //{
            //    using (MyDisposable test = MyDisposable.Create())
            //    {
            //        Console.WriteLine("inside using 1");
            //        test.MyMethod();
            //        Console.WriteLine("inside using 2");
            //    }
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine("MYYYYYY Exception: " + exception);
            //    //throw;
            //}
            //string str = "Data Source=(local);Initial Catalog=MOSAIQ;"
            //             + "Integrated Security=SSPI";
            //try
            //{
            //    using (SqlConnection connection =
            //            new SqlConnection(str))
            //    {
            //        SqlCommand command =
            //                new SqlCommand("select top(2) * from patienttt", connection);
            //        connection.Open();

            //        SqlDataReader reader = command.ExecuteReader();

            //        // Call Read before accessing data.
            //        while (reader.Read())
            //        {
            //            //ReadSingleRow((IDataRecord)reader);
            //        }

            //        // Call Close when done reading.
            //        reader.Close();
            //    }
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine("MYYYYYY Exception: " + exception);
            //    //throw;
            //}

            try
            {
                using (new CrashingDisposable())
                {
                    throw new Exception("Inside using block");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception: " + e.Message);
            }

            return order;
        }

        private class CrashingDisposable : IDisposable
        {
            public void Dispose()
            {
                throw new Exception("Inside Dispose");
            }
        }

        private static void test(char[] blah)
        {
            char[] blah3 = {'1', '2', '3'};
            
            string blah2 = blah.ToString();
        }

        public static int[] ComputeCharClasses(string s, int[] order) 
        {
            var charClass = new int[s.Length];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[order[i]] != s[order[i - 1]])
                    charClass[order[i]] = charClass[order[i - 1]] + 1;
                else
                    charClass[order[i]] = charClass[order[i - 1]];
            }

            return charClass;
        }
    }
}

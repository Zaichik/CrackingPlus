using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscLib
{
    public static class UriExamples
    {
        public static void PrintExamples()
        {
            var uris = new List<Uri>
            {
                new Uri("http://dotnetperls.com/"),
                new Uri(new Uri("http://dotnetperls.com/"), "/datagridview-tips"),
                new Uri("http://dotnetperls.com/Test/Exists.html?good=true"),
                //new Uri("/PluralsightPrismDemo;component/XamlCatalog.xaml", UriKind.Relative)
            };
            // Construct three Uri objects.

            // Write properties.
            foreach (var uri in uris)
                Print(uri);

            var uri2 = new Uri("/PluralsightPrismDemo;component/XamlCatalog.xaml", UriKind.Relative);
            //uri2.
        }

        static void Print(Uri uri)
        {
            // Print properties of Uri instance.
            Console.WriteLine(" -- {0} -- ", uri);
            Console.WriteLine("AbsolutePath = {0}", uri.AbsolutePath);
            Console.WriteLine("AbsoluteUri = {0}", uri.AbsoluteUri);
            Console.WriteLine("Authority = {0}", uri.Authority);
            Console.WriteLine("DnsSafeHost = {0}", uri.DnsSafeHost);
            Console.WriteLine("Fragment = {0}", uri.Fragment);
            Console.WriteLine("Host = {0}", uri.Host);
            Console.WriteLine("HostNameType = {0}", uri.HostNameType);
            Console.WriteLine("IsAbsoluteUri = {0}", uri.IsAbsoluteUri);
            Console.WriteLine("IsDefaultPort = {0}", uri.IsDefaultPort);
            Console.WriteLine("IsFile = {0}", uri.IsFile);
            Console.WriteLine("IsLoopback = {0}", uri.IsLoopback);
            Console.WriteLine("IsUnc = {0}", uri.IsUnc);
            Console.WriteLine("LocalPath = {0}", uri.LocalPath);
            Console.WriteLine("OriginalString = {0}", uri.OriginalString);
            Console.WriteLine("PathAndQuery = {0}", uri.PathAndQuery);
            Console.WriteLine("Port = {0}", uri.Port);
            Console.WriteLine("Query = {0}", uri.Query);
            Console.WriteLine("Scheme = {0}", uri.Scheme);
            Console.WriteLine("Segments = {0}", string.Join(",", uri.Segments));
            Console.WriteLine("UserEscaped = {0}", uri.UserEscaped);
            Console.WriteLine("UserInfo = {0}", uri.UserInfo);
            Console.WriteLine(new string('-', 40));
        }

    }
}

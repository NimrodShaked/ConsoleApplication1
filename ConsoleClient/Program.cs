using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleClient
{
    static class  Program
    {
        static void Main(string[] args)
        {
            bool con = true;
            Console.WriteLine("Enter Client name");
            string str = Console.ReadLine();
            ServiceReference1.HelloWorldServiceClient obj = new ServiceReference1.HelloWorldServiceClient();

            var t = Task.Run(() => {
           
            while (con)
            {
               obj.Call(str);
               Thread.Sleep(10);
            } });

            Console.Read();
            con = false;
            t.Wait();
            Console.WriteLine($" by {str}");
            Console.Read();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using ClassLibrary1;
namespace ConsoleApplication1
{
   static class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address

            //Uri httpUrl = new Uri("net.tcp://localhost:8001/HelloWorld");
            Uri httpUrl = new Uri("http://localhost:8010/MyService/HelloWorld");

            //Create ServiceHost
            ServiceHost host;
            Console.WriteLine("?");
            Console.WriteLine("Enter 1 to Single");
            Console.WriteLine("Enter 2 to Multiple");
            Console.WriteLine("else to Default");

            string ans = Console.ReadLine().Trim();

            if (ans=="1")
            {
                host = new ServiceHost(typeof(ClassLibrary1.HelloWorldServiceSingle), httpUrl);
                Console.WriteLine("Run ConcurrencyMode = ConcurrencyMode.Single");
            }
            else if(ans == "2")
           

            {
                host = new ServiceHost(typeof(ClassLibrary1.HelloWorldServiceMultiple), httpUrl);
                Console.WriteLine("Run ConcurrencyMode = ConcurrencyMode.Multiple");
            }
            else
            {
                host = new ServiceHost(typeof(ClassLibrary1.HelloWorldServiceDef), httpUrl);
                Console.WriteLine("Run ConcurrencyMode = Defualt");


            }


            //Add a service endpoint
            host.AddServiceEndpoint(typeof(ClassLibrary1.IHelloWorldService)
            , new WSHttpBinding(), "");
            
            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            //Start the Service
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();

        }
    }
    

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
namespace ClassLibrary1
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract(IsOneWay=true)]
        void Call(string ClientName);
    }
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class HelloWorldServiceSingle : IHelloWorldService
    {
        public int i;
        public void Call(string ClientName)
        {
            i++;
            Console.WriteLine("+++++++++++ Client name :" + ClientName + " Instance:" + i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() + " Time:" + DateTime.Now.ToString() + "\n\n");
            Thread.Sleep(5000);
            Console.WriteLine("-------- Client name :" + ClientName + " Instance:" + i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() + " Time:" + DateTime.Now.ToString() + "\n\n");
        }


    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class HelloWorldServiceMultiple : IHelloWorldService
    {
        public int i;
        public void Call(string ClientName)
        {
            i++;
            Console.WriteLine("+++++++++++ Client name :" + ClientName + " Instance:" + i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() + " Time:" + DateTime.Now.ToString() + "\n\n");
            Thread.Sleep(5000);
            Console.WriteLine("-------- Client name :" + ClientName + " Instance:" + i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() + " Time:" + DateTime.Now.ToString() + "\n\n");
        }


    }
    
    public class HelloWorldServiceDef: IHelloWorldService
    {
        public int i;
        public void Call(string ClientName)
        {
            i++;
            Console.WriteLine("+++++++++++ Client name :" + ClientName + " Instance:" + i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() + " Time:" + DateTime.Now.ToString() + "\n\n");
            Thread.Sleep(5000);
            Console.WriteLine("-------- Client name :" + ClientName + " Instance:" + i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() + " Time:" + DateTime.Now.ToString() + "\n\n");
        }


    }
}

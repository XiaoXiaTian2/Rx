using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var messenger = new Messenger<string>();

            ////messenger.events.Add((msg) => Console.WriteLine($"added msg: {msg}"));
            //messenger += (msg) => Console.WriteLine($"added msg: {msg}");
            //messenger.Send("origin event");

            NewspaperOffice<Customer> newspaperOffice = new NewspaperOffice<Customer>();
            ISubject<Customer> milkSender = new MilkSender<Customer>();
            Customer customerA = new Customer();
            Customer customerB = new Customer();

            newspaperOffice += customerA;
            newspaperOffice.AddObserver(customerB);
            newspaperOffice.Notify();

            milkSender.AddObserver(customerB);
            milkSender.Notify();

            newspaperOffice.RemoveObserver(customerB);
            newspaperOffice.Notify();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject<string> subject = new Subject<string>();

            Subscription<string> subscriptionA = subject.Subscribe(data => Console.WriteLine(data));
            Subscription<string> subscriptionB = subject.Subscribe(data => Console.WriteLine(data),
                err => Console.WriteLine(err), () => { });
            subject.Next("1");
            subscriptionA.Unsubcribe();
            subject.Next("100");
            subject.Complete();
            subject.Next("1");
        }
    }
}

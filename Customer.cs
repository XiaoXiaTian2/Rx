using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerPractice
{
    class Customer : IObeserver
    {
        public void Update(string type)
        {
            Console.WriteLine($"收到{type}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerPractice
{
    internal interface ISubject<T>
    {
        IList<T> observers { get; set; }
        void AddObserver(T observer);
        void RemoveObserver(T observer);
        void Notify();
    }
}

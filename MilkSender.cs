using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerPractice
{
    internal class MilkSender<TObeserver> : ISubject<TObeserver> where TObeserver : IObeserver, new()
    {
        private IList<TObeserver> _observers;
        public IList<TObeserver> observers { get => _observers; set => _observers = value; }

        public MilkSender()
        {
            _observers = new List<TObeserver>();
        }

        public void AddObserver(TObeserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            foreach (TObeserver obs in _observers)
            {
                obs.Update("牛奶");
            }
        }

        public void RemoveObserver(TObeserver observer)
        {
            _observers.Remove(observer);
        }
    }
}

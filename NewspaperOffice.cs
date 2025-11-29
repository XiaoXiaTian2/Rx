using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerPractice
{
    class NewspaperOffice<TObeserver> : ISubject<TObeserver> where TObeserver : IObeserver, new()
    {
        private IList<TObeserver> _observers;
        public IList<TObeserver> observers { get => _observers; set => _observers = value; }

        public static NewspaperOffice<TObeserver> operator +(NewspaperOffice<TObeserver> operand, TObeserver obeserver)
        {
            operand.observers.Add(obeserver);
            return operand;
        }

        public NewspaperOffice()
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
                obs.Update("報紙");
            }
        }

        public void RemoveObserver(TObeserver observer)
        {
            _observers.Remove(observer);
        }
    }
}

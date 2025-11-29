using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx
{
    public class Subject<T>
    {
        private List<IObserver<T>> _observers = new List<IObserver<T>>();

        public Subject() { }

        public Subscription<T> Subscribe(Action<T> onNext, Action<string> onError = null, Action onCompleted = null)
        {
            IObserver<T> observer = new Observer<T>
            {
                Next = onNext,
                Error = onError,
                Complete = onCompleted,
            };
            _observers.Add(observer);

            return new Subscription<T>(this, observer);
        }

        public void Next(T num)
        {
            foreach (IObserver<T> observer in _observers)
            {
                try
                {
                    observer.OnNext(num);
                }
                catch (Exception e)
                {
                    observer.OnError(e.Message);
                }
            }
        }

        //public void Error() { }
        public void Complete()
        {
            _observers.Clear(); ;
        }

        internal void Remove(IObserver<T> observer)
        {
            _observers.Remove(observer);
        }
    }
}

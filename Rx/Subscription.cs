using System.Collections.Generic;

namespace Rx
{
    public class Subscription<T>
    {
        private Subject<T> subject;
        private IObserver<T> _observer;
        public Subscription(Subject<T> subject, IObserver<T> observer)
        {
            this.subject = subject;
            _observer = observer;
        }

        public void Unsubcribe()
        {
            this.subject.Remove(_observer);
        }
    }
}
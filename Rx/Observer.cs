using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx
{
    public class Observer<T> : IObserver<T>
    {
        public Action<T> Next;
        public Action<string> Error;
        public Action Complete;
        public void OnNext(T num)
        {
            Next?.Invoke(num);
        }
        public void OnError(string e)
        {
            Error?.Invoke(e);
        }
        public void OnComplete()
        {
            Complete?.Invoke();
        }
    }
}

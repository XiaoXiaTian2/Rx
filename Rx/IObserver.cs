using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx
{
    public interface IObserver<T>
    {
        void OnNext(T num);
        void OnError(string e);
        void OnComplete();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerPractice
{
    public class Messenger<T>
    {
        public event EventHandler<T> On;
        public List<Action<T>> events = new List<Action<T>>();

        public static Messenger<T> operator +(Messenger<T> operand, Action<T> action)
        {
            operand.events.Add(action);
            return operand;
        }

        public void Send(T msg)
        {
            Console.WriteLine($"origin msg: {msg}");

            foreach (var evt in events)
            {
                evt?.Invoke(msg);
            }
        }
    }
}

using System;

namespace Three
{
    public class SimpleStack<T> : SimpleList<T>
        where T : IComparable
    {
        public void Push(T e)
        {
            first = new SimpleListItem<T>(e)
            {
                next = first
            };
        }

        public T Pop()
        {
            var x = first;
            first = first.next;
            return x.data;
        }

        public override string ToString()
        {
            var tmp = first;
            var str = "";
            while (tmp != null)
            {
                str += tmp.data.ToString() + "\n";
                tmp = tmp.next;
            }

            return str;
        }
    }
}
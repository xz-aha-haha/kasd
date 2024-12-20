using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MyVector;

namespace MyStack
{
    public class MyStack<T> : MyVector<T>
    {
        public MyStack()
            : base() { }

        public void Push(T item)
        {
            base.Add(item);
        }
        public T Pop()
        {
            T x = base.LastElement();
            base.Remove(x);
            return x;
        }
        public T Peek()
        {
            return base.LastElement();
        }
        public bool Empty()
        {
            return base.IsEmpty();
        }
        public int Seek(T item)
        {
            if (base.Contains(item))
                return base.IndexOf(item) + 1;
            return -1;
        }

    }
}
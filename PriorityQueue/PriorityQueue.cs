using PriorityQueue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
    {
        private Node top;
        public int Count { get; set; }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T item)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}

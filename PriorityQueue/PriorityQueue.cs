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
        private Node<T> top;
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
            return Count == 0;
        }

        public T Peek()
        {
            if(!IsEmpty())
            {
                return top.Item;
            }
            else
            {
                throw new InvalidOperationException("Cannot obtain top of empty priority queue.");
            }
        }
    }
}

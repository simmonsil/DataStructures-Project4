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
            if(Count == 0)
            {
                top = new Node<T>(item, null);
            }
            else
            {
                Node<T> current = top;
                Node<T> previous = null;

                while (current != null && current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;
                }

                Node<T> newNode = new Node<T>(item, current);

                if(previous != null)
                {
                    previous.Next = newNode;
                }
                else
                {
                    top = newNode;
                }

            }
            Count++;
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

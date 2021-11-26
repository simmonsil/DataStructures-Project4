using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Interfaces
{
    public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
    {
        // Inserts item based on its priority
        void Enqueue(T item);
        void Dequeue();
        T Peek();
    }
}

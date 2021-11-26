using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class Node<T> where T: IComparable
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> link)
        {
            Item = value;
            Next = link;
        }
    }
}

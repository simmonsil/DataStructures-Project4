using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProject4Driver
{
    public class Customer
    {
        public Evnt EnterEvent { get; set; } = null;
        public Evnt LeavingEvent { get; set; } = null;
        public int CustomerId { get; set; }
    }
}

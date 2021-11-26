using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public enum EVENTTYPE { ENTER, LEAVE }

    public class Evnt : IComparable
    {
        public EVENTTYPE Type { get; set; }
        public DateTime Time { get; set; }
        public int Patron { get; set; }

        public Evnt()
        {
            Type = EVENTTYPE.ENTER;
            Time = DateTime.Now;
            Patron = -1;
        }

        public Evnt(EVENTTYPE type, DateTime time, int patron)
        {
            Type = type;
            Time = time;
            Patron = patron;
        }

        public override string ToString()
        {
            String str = "";

            str += String.Format("Patron {0}", Patron.ToString().PadLeft(3));
            str += Type + "'s";
            str += String.Format(" at {0}", Time.ToShortTimeString().PadLeft(8));

            return str;
        }
        public int CompareTo(Object obj)
        {
            if (!(obj is Evnt))
                throw new ArgumentException("The arguement is not an event object.");

            Evnt e = (Evnt)obj;
            return (e.Time.CompareTo(Time));
        }
    }
}

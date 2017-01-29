using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellMeDayOfTheWeek
{
    public class CustomWeekDayManager
    {
        private string[] daysOfWeek = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

        //indexer
        public int this[string index]
        {
            get
            {
                if(daysOfWeek.Any(d=>d==index)) return Array.IndexOf(daysOfWeek, index) + 1;
                throw new Exception("No such day exists");
            }
        }
    }
}

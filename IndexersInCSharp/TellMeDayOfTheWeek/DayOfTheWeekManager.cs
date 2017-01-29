using System;

namespace TellMeDayOfTheWeek
{
    public class DayOfTheWeekManager
    {
        //indexer
        public int this[string index]
        {
            get
            {
                if(index !=DayOfWeek.Monday.ToString() && index != DayOfWeek.Tuesday.ToString() && index != DayOfWeek.Wednesday.ToString() && index != DayOfWeek.Thursday.ToString() && index != DayOfWeek.Friday.ToString() && index != DayOfWeek.Saturday.ToString() && index != DayOfWeek.Sunday.ToString()) throw new Exception("There is no such week day");
                var dayOfWeek = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), index);
                return (int)dayOfWeek;
            }
        }
    }
}

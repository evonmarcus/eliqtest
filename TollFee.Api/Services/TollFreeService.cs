using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TollFee.Api.Services
{
    public static class TollFreeService
    {
        public static bool IsTollFree(DateTime passage)
        {
            try
            {
                var isHoliday = ReadFreeDatesFromFile(passage.Date.Year, passage.Date.Month, passage.Date.Day);

                if (passage.DayOfWeek != DayOfWeek.Saturday && passage.DayOfWeek != DayOfWeek.Sunday && !isHoliday && passage.Month != 7)
                    return false;

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Free dates configurable runtime to read from a file
        public static bool ReadFreeDatesFromFile(int year, int month, int day)
        {
            try
            {
                var xml = XDocument.Load(@"FreeDates.xml");
                var query = from c in xml.Root.Descendants("date")
                            where (int)c.Element("year") == year & (int)c.Element("month") == month & (int)c.Element("day") == day
                            select c.Element("year").Value + " " +
                                   c.Element("month").Value + " " +
                                   c.Element("day").Value;

                return query != null ? query.ToList().Count > 0 : false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

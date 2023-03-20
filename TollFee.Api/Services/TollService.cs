using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollFee.Api.Services
{
    public class TollService : ITollService
    {
        public int GetTollFee(DateTime[] request)
        {
            var totalFee = 0;

            try
            {
                // group by date since the calculation should be done based on the date of the month
                var groupedByDateList = request.GroupBy(u => u.Date).Select(grp => grp.ToArray()).ToArray();

                foreach (var item in groupedByDateList)
                {
                    totalFee += TollFeeService.GetTollFeeForTheDay(item);

                }

                return totalFee;
            }
            catch (Exception)
            {
                throw;
            }

        }

        
    }
}

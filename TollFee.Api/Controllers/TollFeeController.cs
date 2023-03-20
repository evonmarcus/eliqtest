using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TollFee.Api.Models;
using TollFee.Api.Services;

namespace TollFee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TollFeeController : ControllerBase
    {
        private readonly ITollService _tollService;
        public TollFeeController(ITollService tollService)
        {
            _tollService = tollService ?? throw new ArgumentNullException(nameof(tollService));
        }

        [HttpGet]
        public CalculateFeeResponse CalculateFee([FromQuery]DateTime[] request)
        {
            try
            {
                var response = new CalculateFeeResponse();

                if (request != null)
                {
                    // order the request list by date and time
                    var newrequest = request.OrderBy(x => x.Date).ThenBy(x => x.Hour).ThenBy(x => x.Minute).ToArray();

                    var totalFee = new TollService().GetTollFee(newrequest);

                    response.TotalFee = totalFee;
                    response.AverageFeePerDay = totalFee / request.Distinct().Count();
                }
                else
                {
                    response.TotalFee = 0;
                    response.AverageFeePerDay = 0;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

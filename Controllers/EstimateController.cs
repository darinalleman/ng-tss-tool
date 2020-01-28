using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dynastream.Fit;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Models;

namespace WebApplication.Controllers
{
    public class EstimateController : Controller
    {
        [HttpPost, Route("api/Estimate")]
        public IActionResult Estimate([FromBody] int[] zones)
        {
            try{
                var zonesInt = new List<int>();
                foreach (int z in zones)
                {
                    Console.WriteLine("added + " + z );
                    zonesInt.Add(Convert.ToInt32(z));
                }
                var tss = TSSEstimator.FromHeartRate(zonesInt, HeartRateLogger.Instance.HeartRates);
                return Ok((new { tss }));
            }
            catch (Exception ex) {
                var originalMessage = ex.Message;

                while (ex.InnerException != null)
                    ex = ex.InnerException;
                    return BadRequest($"{originalMessage} | {ex.Message}");
            }
        }
    }
}

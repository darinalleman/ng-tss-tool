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
        [HttpPost, Route("api/Estimate/{fileId:guid}")]
        public IActionResult Estimate([FromBody] int[] zones, Guid fileId)
        {
            Console.WriteLine(fileId);
            try{
                var zonesInt = new List<int>();
                foreach (int z in zones)
                {
                    zonesInt.Add(Convert.ToInt32(z));
                }
                var tss = TSSEstimator.FromHeartRate(zonesInt, HeartRateLogger.Instance.HeartRates);
                var FilePath = Path.Combine(  
                  Directory.GetCurrentDirectory(), "wwwroot", "Uploads",   
                  fileId.ToString());
                //now that we've estimated it, we can delete it
                //this may be removed in the future if we need it for othe things
                System.IO.File.Delete(FilePath);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            try{
                var zonesInt = new List<int>();
                foreach (int z in zones)
                {
                    zonesInt.Add(Convert.ToInt32(z));
                }
                var tss = TSSEstimator.FromHeartRate(zonesInt, HeartRateLogger.Instance.HeartRates);
                var averagePowerMissingFTP = tss*36/ElapsedTimeLogger.Instance.ElapsedTime; //need to multiply by FTP^2 and then take the square root of that
                var FilePath = Path.Combine(  
                  Directory.GetCurrentDirectory(), "wwwroot", "Uploads",   
                  fileId.ToString());
                // //now that we've estimated it, we can delete it
                // //this may be removed in the future if we need it for othe things
                // System.IO.File.Delete(FilePath);
                return Ok((new { tss, averagePowerMissingFTP }));
            }
            catch (Exception ex) {
                var originalMessage = ex.Message;

                while (ex.InnerException != null)
                    ex = ex.InnerException;
                    return BadRequest($"{originalMessage} | {ex.Message}");
            }
        }

        [HttpPost, Route("api/Modify/{fileId:guid}")]
        public IActionResult Modify([FromBody] int watts, Guid fileId)
        {
            try{
                TSSTool.AveragePower = watts;
                var NewFilePath = Path.Combine(  
                  Directory.GetCurrentDirectory(), "wwwroot", "Downloads",   
                  "" + DateTime.Now.ToString("yyyy-MM-dd-ffff") + ".fit");
                // var averagePowerMissingFTP = tss*36/ElapsedTimeLogger.Instance.ElapsedTime; //need to multiply by FTP^2 and then take the square root of that

                Boolean DecodeResult;
                Boolean result = false;
  
                DecodeResult = TSSTool.GetInstance().EncodeFile(
                    new FileStream(NewFilePath, FileMode.Create, FileAccess.ReadWrite),
                    new FileStream(Path.Combine(  
                        Directory.GetCurrentDirectory(), "wwwroot", "Uploads",   
                            fileId.ToString()), FileMode.Open));
                result = DecodeResult;
                
                return Ok();
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

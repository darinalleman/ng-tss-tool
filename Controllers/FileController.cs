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
    public class FileController : Controller
    {
        [HttpPost, Route("api/Upload")]
        public async Task<IActionResult> Upload()
        {
            try{
                var form = await Request.ReadFormAsync();
                var file = form.Files.First();
                if (file == null) return null;
                long size = file.Length;
                Console.WriteLine("***File Upload***");
                Console.WriteLine(file.FileName);

                var FilePath = "";
                Guid FileId = Guid.NewGuid();
                
                FilePath = Path.Combine(  
                  Directory.GetCurrentDirectory(), "wwwroot", "Uploads",   
                  FileId.ToString());
            

                Boolean DecodeResult;
                Boolean result = false;
                int ElapsedTime = 0;

                if (size > 0)
                {
                    using (var stream = new FileStream(FilePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    DecodeResult = TSSTool.GetInstance().DecodeFile(new FileStream(FilePath, FileMode.Open));
                    ElapsedTime = ElapsedTimeLogger.Instance.ElapsedTime;
                    result = DecodeResult;
                }

                return Ok(new { size, FileId, result, ElapsedTime });
            }
            catch (Exception ex) {
                var originalMessage = ex.Message;

                while (ex.InnerException != null)
                    ex = ex.InnerException;
                    return BadRequest($"{originalMessage} | {ex.Message}");
            }
        }

        [HttpGet, Route("api/Download/{fileId:guid}")]
        public IActionResult Download(Guid fileId) 
        {
            var NewFilePath = Path.Combine(  
                  Directory.GetCurrentDirectory(), "wwwroot", "Downloads",   
                  "" + fileId.ToString() + ".fit");
            var FileStream = new FileStream(NewFilePath, FileMode.Open, FileAccess.Read);
            return File(FileStream, "application/octet-stream");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace EelamHeroes.Controller
{
    public class UploadController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IWebHostEnvironment environment;
        private static readonly Random Random = new Random();

        public UploadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpGet("pdf")]
        public IActionResult GetPdf()
        {
            //CreateImage();

            return Ok();
        }

        [HttpPost("upload/single")]
        public IActionResult Single(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    var randomString = RandomString(20);
                    var folderPath = $"images/post/{DateTime.Now.Year}";
                    return Ok(UploadFileToUrl(file, folderPath, randomString + ".jpg"));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        [Route("api/Image/Save")]
        public void Save(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var file in UploadFiles)
                {
                    {
                        var randomString = RandomString(20);
                        var folderPath = $"images/post/{DateTime.Now.Year}";
                        var imageFileName = UploadFileToUrl(file, folderPath, randomString + ".jpg");
                        Response.Headers.Add("name", imageFileName);
                        Response.StatusCode = 200;
                        Response.ContentType = "application/json; charset=utf-8";
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
        [HttpPost("upload/hero/{id}")]
        public IActionResult Hero(int id, IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    return Ok(UploadFileToUrl(file, "images/hero", id + ".jpg"));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
        private string UploadFileToUrl(IFormFile file, string folderPath, string fileName)
        {
            var folder = Path.Combine(environment.WebRootPath, folderPath);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            var filePath = Path.Combine(folder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var pathToDatabase = Path.Combine(folderPath, fileName);
            return pathToDatabase;

        }
    }
}
using System;
using System.IO;
using FileUploading.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploading.Controllers
{
    public class ImagesController:Controller
    {
        private IWebHostEnvironment _environment;

        public ImagesController(IWebHostEnvironment env)
        {
            _environment = env;
        }
        [HttpGet]
        public IActionResult Uploads()
        {
            Console.WriteLine("the count isssssssssssssssssss ");
            return View("Upload");
        }
        [HttpPost]
        public IActionResult Create(Image image)
        {
            if (image.form.Count==0)
            {
                RedirectToAction("Uploads");
            }
            foreach (var formFile in image.form)
            {
                var guid = Guid.NewGuid();
                var unique = guid+ "_" + formFile.FileName;
                var path = Path.Combine(_environment.WebRootPath,"images",unique);
                formFile.CopyTo(new FileStream(path,FileMode.Create));
            }
            Console.WriteLine("Say allah");
            return RedirectToAction("Success");
        }


        public IActionResult Success()
        {
            return View("success");
        }
    }
}
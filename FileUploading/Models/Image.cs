using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FileUploading.Models
{
    public class Image
    {
        public List<IFormFile> form { set; get; }

       
    }
}
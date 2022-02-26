using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication3.Areas.AdminPanel.Data
{
    public static class Extensions
    {
        public static bool isImage(this IFormFile formFile)
        {
            return formFile.ContentType.Contains("image");
        }
        public static bool AllowedSize(this IFormFile formFile, double mb)
        {
            return formFile.Length> mb * 1024 * 1000; 
        }
         public static async Task<string> GenerateFile(this IFormFile formFile, string folerPath)
         {
            var fileaName =$"{Guid.NewGuid()}-{formFile.FileName}";
            var path=Path.Combine(folerPath, fileaName);

            using (var fileStream = new FileStream(path, FileMode.CreateNew)) 
            {
                await formFile.CopyToAsync(fileStream);
            }
            return fileaName;
         }
    }
}

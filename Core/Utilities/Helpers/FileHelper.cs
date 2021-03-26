using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string  CreateNewPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;
            string tempPath = Environment.CurrentDirectory+ @"\wwwroot\Images";
            var newPath= Guid.NewGuid().ToString() + fileExtension;
            string result = $@"{tempPath}\{newPath}";
            return result;
        }
        public static string AddAsync(IFormFile formFile)
        {
            
            var sourcePath = Path.GetTempFileName();
            using (var stream = new FileStream(sourcePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            var result = CreateNewPath(formFile);
            File.Move(sourcePath, result);
            return result.Replace("\\","/");
        }
        public static string UpdateAsync(string sourcePath, IFormFile formFile)
        {
            var result = CreateNewPath(formFile);
            using (var stream = new FileStream(result, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            File.Delete(sourcePath);
            return result;
        }
        public static IResult DeleteAsync(string path)
        {
            File.Delete(path);
            return new SuccessResult();
        }
    }
}

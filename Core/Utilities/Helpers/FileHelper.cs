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
        public static (string newPath,string tempPath )CreateNewPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;
            var uniqueFileName = Guid.NewGuid().ToString("N") + fileExtension;
            string result = $"{Environment.CurrentDirectory + $@"\wwwroot\Images\"}{uniqueFileName}";
            return (result, $@"\Images\{uniqueFileName}");
        }
        public static string AddAsync(IFormFile formFile)
        {
            var result = CreateNewPath(formFile);
            var sourcePath = Path.GetTempFileName();
            using (var stream = new FileStream(sourcePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            File.Move(sourcePath, result.newPath);
            return result.tempPath;
        }
        public static string UpdateAsync(string sourcePath, IFormFile formFile)
        {
            var result = CreateNewPath(formFile);
            using (var stream = new FileStream(result.newPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            File.Delete(sourcePath);
            return result.tempPath;
        }
        public static IResult DeleteAsync(string path)
        {
            File.Delete(path);
            return new SuccessResult();
        }
    }
}

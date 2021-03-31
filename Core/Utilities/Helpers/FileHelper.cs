using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public  class FileHelper
    {

        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        static string path = @"Images\";

        public static string AddAsync(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string newFileName = Guid.NewGuid().ToString("N") + extension;

            if (!Directory.Exists(directory + path))
            {
                Directory.CreateDirectory(directory + path);
            }

            using (FileStream fileStream = File.Create(directory + path + newFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }


            return (path + newFileName).Replace("\\", "/");
        }


        public static IResult DeleteAsync(string imagePath)
        {
            if (File.Exists(directory + imagePath.Replace("/", "\\")) && Path.GetFileName(imagePath) != "default.jpg")
            {
                File.Delete(directory + imagePath.Replace("/", "\\"));
            }
            return new SuccessResult();
        }


        public static string UpdateAsync( string sourcePath, IFormFile file)
        {
            DeleteAsync(sourcePath);
            return AddAsync(file);


        }
    }
}

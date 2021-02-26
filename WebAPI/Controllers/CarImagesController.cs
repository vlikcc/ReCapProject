using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService,IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromForm(Name ="Image")] IFormFile file,[FromForm] CarImage image)
        {
            FileInfo filename =  new  FileInfo(file.FileName);
            string fileExtension = filename.Extension;
            var imagePath = Path.GetTempFileName();
            if (file.Length >0)
            {
                using (var stream = new FileStream(imagePath, FileMode.Create))
                
                    await file.CopyToAsync(stream);
                    var carimage = new CarImage();
                    carimage.CarId = image.CarId;
                    carimage.ImagePath = imagePath;
                    carimage.Date = DateTime.Now;
                var result = _carImageService.AddWithExtension(image, fileExtension);
                

            }
            return BadRequest();
        }

    }
}

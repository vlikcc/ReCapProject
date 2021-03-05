using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService:IEntityService<CarImage>
    {
        IResult AddWithExtensions(CarImage carImage, IFormFile file);
        IResult GetImagesByCarId(int carId);
        IResult UpdateWithExtensions(CarImage carImage, IFormFile file);
    }
}

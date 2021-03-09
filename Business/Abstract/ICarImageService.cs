using Core.Services;
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
        IResult Add2(CarImage carImage, IFormFile file);
        IResult Update2(CarImage carImage, IFormFile file);
        IResult GetImagesByCarId(int carId);
    }
}

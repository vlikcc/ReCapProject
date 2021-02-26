using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService:IEntityService<CarImage>
    {
        IResult AddWithExtension(CarImage carImage, string extension);
        IDataResult<List<CarImage>> GetImagesByCarId(int CarId);

    }
}

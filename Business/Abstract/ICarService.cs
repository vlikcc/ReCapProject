using Core.Services;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IEntityService<Car>
    {
       
        IDataResult<List<Car>> GetCarsByBrandId(int BrandId);
        IDataResult<List<Car>> GetCarsByColorId(int ColorId);       
        IDataResult<List<CarDetailsDto>> GetCarDetails();



    }
}

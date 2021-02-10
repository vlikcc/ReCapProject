using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal :EfEntityRepositoryBase<Car,CarRentalContext >,ICarDal 
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars
                             on b.Id equals c.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.Id 
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName =col.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                             
                return result.ToList();
            }
        }
    }
}

﻿using Core.DataAccess;
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
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id                             
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 ImagePath = (from image in context.CarImages where image.CarId == c.Id select image.ImagePath).ToArray() 
                                
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}

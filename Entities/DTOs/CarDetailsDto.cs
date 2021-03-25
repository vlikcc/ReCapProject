using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string []  ImagePath { get; set; }



    }
}

//SELECT  dbo.Cars.Id,
//        dbo.Cars.CarName, 
//        dbo.Cars.ModelYear, 
//        dbo.Cars.DailyPrice, 
//        dbo.Cars.Description, 
//        dbo.Brands.BrandName, 
//        dbo.Colors.ColorName, 
//        dbo.CarImages.ImagePath
//FROM            dbo.Cars INNER JOIN
//                         dbo.Brands ON dbo.Cars.BrandId = dbo.Brands.Id INNER JOIN
//                         dbo.Colors ON dbo.Cars.ColorId = dbo.Colors.Id INNER JOIN
//                        
//                         dbo.CarImages ON dbo.Cars.Id = dbo.CarImages.CarId
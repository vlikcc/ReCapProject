using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<CarColor> GetAll();
        List<CarColor> GetColorsById(int Id);        
        void Add(CarColor color);
        void Update(CarColor color);
        void Delete(CarColor color);
        
    }
}

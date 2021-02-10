using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        ICarColorDal colorDal;

        public ColorManager(ICarColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        public void Add(CarColor color)
        {
            colorDal.Add(color);
        }

        public void Delete(CarColor color)
        {
            colorDal.Delete(color);
        }

        public List<CarColor> GetAll()
        {
            return colorDal.GetAll();
        }

        public List<CarColor> GetColorsById(int Id)
        {
            return colorDal.GetAll(c => c.Id == Id);
        }

        public void Update(CarColor color)
        {
            colorDal.Update(color);
        }
    }
}

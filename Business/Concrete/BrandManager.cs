using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return brandDal.GetAll();
        }

        public List<Brand> GetBrandsById(int Id)
        {
            return brandDal.GetAll(b => b.Id == Id);
        }

        public void Update(Brand brand)
        {
            brandDal.Update(brand);
        }

        
    }
}

using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();        
        List<Brand> GetBrandsById(int Id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
        

    }
}

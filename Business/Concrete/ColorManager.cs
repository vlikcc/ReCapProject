using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    [ValidationAspect(typeof(ColorValidator))]
    public class ColorManager : IColorService
    {
        public IResult Add(CarColor entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarColor entitiy)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarColor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarColor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarColor entity)
        {
            throw new NotImplementedException();
        }
    }
}

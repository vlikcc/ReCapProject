﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //[ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult DeleteCarByCarId(int CarId)
        {
            _carDal.DeleteCarByCarId(CarId);
            return new SuccessResult();
        }


        //[CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        //[CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==id));
        }

        [CacheAspect]
        public IDataResult <List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(cd=>cd.BrandId==BrandId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByCarId(int CarId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(cd => cd.CarId == CarId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(cd => cd.ColorId == ColorId));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == BrandId));
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == ColorId));
        }

        //[ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        
    }
}

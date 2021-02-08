using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal :ICarDal
    {
        List<Car> _cars;

       

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id =1,BrandId=2,ColorId =3,DailyPrice =450,ModelYear =2016,Description ="Volkswagen Polo 1.4 TDCI"},
                new Car {Id =2,BrandId=2,ColorId =1,DailyPrice =525,ModelYear =2018,Description ="Volkswagen Golf 1.6 TDCI Otomatik Vites"},
                new Car {Id =3,BrandId=1,ColorId =2,DailyPrice =1000,ModelYear=2019,Description ="Mercedes A180 AMG 1.6 Dizel Otomatik Vites"},
                new Car {Id =4,BrandId=3,ColorId =5,DailyPrice =500,ModelYear =2017,Description ="Opel Astra  1.6 TDCI"},               
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carForDelete;
            carForDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car car)
        {
           return  _cars.Where(c => c.Id == car.Id).ToList();
        }

        public void Update(Car car)
        {
            Car carForUpdate;
           carForUpdate= _cars.SingleOrDefault(c => c.Id == car.Id);
            carForUpdate.BrandId = car.BrandId;
            carForUpdate.ColorId = car.ColorId;
            carForUpdate.DailyPrice = car.DailyPrice;
            carForUpdate.ModelYear = car.ModelYear;
            carForUpdate.Description = car.Description;
        }

        List<CarDetailsDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}

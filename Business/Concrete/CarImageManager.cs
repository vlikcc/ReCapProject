using Business.Abstract;
using Business.Constants;
using Core.Services;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult AddFromFile(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Add(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage carImage)
        {
            CarImage imageForDelete = _carImageDal.Get(c => c.Id == carImage.Id);
            FileHelper.DeleteAsync(imageForDelete.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }
        public IResult GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(carImage => carImage.CarId == carId);
            if (!result.Any())
            {
                List<CarImage> carImages = new List<CarImage>()
                {
                    new CarImage {
                        CarId = carId,
                        ImagePath = @"\Images\defaultCar.png",
                        Date = DateTime.Now
                    } 
                };
                return new SuccessDataResult<List<CarImage>>(carImages);
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult UpdateFromFile(CarImage carImage, IFormFile file)
        {
            CarImage imageForUpdate = _carImageDal.Get(c => c.Id == carImage.Id);
            var imagePath = imageForUpdate.ImagePath;
            carImage.ImagePath = FileHelper.UpdateAsync(imagePath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult Update(CarImage entity)
        {
            throw new NotImplementedException();
        }
        private IResult CheckImageLimit(CarImage carImage)
        {
            List<CarImage> carImages = _carImageDal.GetAll(c => c.CarId == carImage.CarId);
            if (carImages.Count > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();

        }
    }
}

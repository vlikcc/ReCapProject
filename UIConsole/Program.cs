using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal ());
            var result = carManager.GetCarDetails();
            foreach (var item in result)
            {
                Console.WriteLine(item.CarName);
            }
            

            

        }
    }
}

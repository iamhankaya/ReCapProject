using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.DailyPrice>0 && car.Description.Length>2)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Kiralama fiyatı 0'dan büyük olmalı!");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

       
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return  _carDal.GetAll(p =>p.ColorId == colorId);
        }

        public List<CarDetailsDTO> GetCarDetails()
        {
            return _carDal.GetCarDetail();
        }
    }
}

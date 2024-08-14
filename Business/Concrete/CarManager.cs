using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Business.Constants;
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

        public Result Add(Car entity)
        {
            if (entity.Description.Length < 2)
            {
                return new ErrorResult(Messages.InvalidCarDescription);
            }

            _carDal.Add(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public Result Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public DataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsSuccessfullyListed);
        }

        public DataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), Messages.CarsSuccessfullyListed);
        }

        public DataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId), Messages.CarsSuccessfullyListed);
        }

        public DataResult<List<CarDetailsDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDTO>>(_carDal.GetCarDetail(),Messages.CarsSuccessfullyListed);
        }

        public Result Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}

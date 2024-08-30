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
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car entity)
        {
            

            _carDal.Add(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
        //[SecuredOperation("cars.getall")]
        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsSuccessfullyListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), Messages.CarsSuccessfullyListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId), Messages.CarsSuccessfullyListed);
        }

        public IDataResult<List<CarDetailsDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDTO>>(_carDal.GetCarDetail(),Messages.CarsSuccessfullyListed);
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        
    }
}

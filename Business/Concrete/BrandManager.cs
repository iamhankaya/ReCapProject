using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Business.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public Result Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public Result Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public DataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsSuccessfullyListed);
        }

        public Result Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}

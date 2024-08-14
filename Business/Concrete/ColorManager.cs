using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public Result Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public Result Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public DataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsSuccessfullyListed);
        }

        public Result Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}

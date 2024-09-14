using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService : IService<Car>
    {
        IDataResult<List<CarDetailsDTO>> GetCarDetails();
        IDataResult<List<CarDetailsDTO>> GetAllByBrandId(int id);
        IDataResult<List<CarDetailsDTO>> GetAllByColorId(int id);
    }
}

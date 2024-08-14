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
        DataResult<List<CarDetailsDTO>> GetCarDetails();
        DataResult<List<Car>> GetAllByBrandId(int id);
        DataResult<List<Car>> GetAllByColorId(int id);
    }
}

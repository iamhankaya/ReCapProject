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
    public interface IRentalService : IService<Rental>
    {
        IResult RentCar(int customerId,int carId);
        IResult ReturnCar (int carId);
        IDataResult<List<SpesificCarRentalDetail>> GetCarRentalDetails(int carId);
        IDataResult<List<SpesificCustomerRentalDetail>> GetCustomerRentalDetails(int customerId);
    }
}

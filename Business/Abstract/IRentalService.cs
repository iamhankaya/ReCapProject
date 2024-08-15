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
        Result RentCar(int customerId,int carId);
        Result ReturnCar (int carId);
        DataResult<List<SpesificCarRentalDetail>> GetCarRentalDetails(int carId);
        DataResult<List<SpesificCustomerRentalDetail>> GetCustomerRentalDetails(int customerId);
    }
}

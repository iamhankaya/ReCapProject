using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        void RentCar(int customerId,int carId,int rentalId);
        Rental ReturnCar(int carId);
        List<SpesificCarRentalDetail> GetCarRentDetail(int carId,Expression<Func<IDto, bool>> filter = null);
        List<SpesificCustomerRentalDetail> GetCustomerRentalDetails(int customerId,Expression<Func<IDto, bool>> filter = null);
    }
}

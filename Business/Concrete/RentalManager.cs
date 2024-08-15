using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public Result Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public Result Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public DataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),"asd");
        }

        public DataResult<List<SpesificCarRentalDetail>> GetCarRentalDetails(int carId)
        {
            return new SuccessDataResult<List<SpesificCarRentalDetail>>(_rentalDal.GetCarRentDetail(carId));
        }

        public DataResult<List<SpesificCustomerRentalDetail>> GetCustomerRentalDetails(int customerId)
        {
            return new SuccessDataResult<List<SpesificCustomerRentalDetail>>(_rentalDal.GetCustomerRentalDetails(customerId));
        }

        public Result RentCar(int customerId, int carId)
        {
            foreach (var r in _rentalDal.GetAll(r => r.CarId==carId))
            {
                if (r.ReturnDate == "Not Returned")
                {
                    return new ErrorResult("Araba henüz geri verilmemiş");

                }
            }
            _rentalDal.RentCar(customerId, carId,this.GetAll().data == null ? 1 :this.GetAll().data.Count + 1 );
            return new SuccessResult(Messages.SuccessfullyRented);
        }

        public Result ReturnCar(int carId)
        {
            _rentalDal.ReturnCar(carId);
            return new SuccessResult(Messages.SuccessfullyReturned);
        }

        public Result Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}

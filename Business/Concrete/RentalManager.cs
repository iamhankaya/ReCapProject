using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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

        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),"asd");
        }

        public IDataResult<List<SpesificCarRentalDetail>> GetCarRentalDetails(int carId)
        {
            return new SuccessDataResult<List<SpesificCarRentalDetail>>(_rentalDal.GetCarRentDetail(carId));
        }

        public IDataResult<List<SpesificCustomerRentalDetail>> GetCustomerRentalDetails(int customerId)
        {
            return new SuccessDataResult<List<SpesificCustomerRentalDetail>>(_rentalDal.GetCustomerRentalDetails(customerId));
        }

        public IResult RentCar(int customerId, int carId)
        {
            IResult result = BusinessRules.Run(CheckIfTheCarAlreadyRented(carId));  
            if (result != null)
                return result;

                _rentalDal.RentCar(customerId, carId,this.GetAll().data == null ? 1 :this.GetAll().data.Count + 1 );
            return new SuccessResult(Messages.SuccessfullyRented);
        }

        public IResult ReturnCar(int carId)
        {
           IResult result = BusinessRules.Run(CheckIfCarIdInReturnCarNull(carId));
           if (result != null)
                return result;

           _rentalDal.ReturnCar(carId);
           return new SuccessResult(Messages.SuccessfullyReturned);

        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        private IResult CheckIfCarIdInReturnCarNull(int carId)
        {
            if (_rentalDal.ReturnCar(carId) == null)
                return new ErrorResult(Messages.ThisCarAlreadyReturned);
            return new SuccessResult();
        }
        
        private IResult CheckIfTheCarAlreadyRented(int carId)
        {
            foreach (var r in _rentalDal.GetAll(r => r.CarId == carId))
            {
                if (r.ReturnDate == "Not Returned")
                    return new ErrorResult("Araba henüz geri verilmemiş");
            }
            return new SuccessResult();
        }
    }
}

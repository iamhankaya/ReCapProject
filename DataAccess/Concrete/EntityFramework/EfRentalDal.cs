using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public void RentCar(int customerId, int carId, int rentalId)
        {
            Rental rental = new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                Id = rentalId,
                RentDate = DateTime.Now.ToString(),
                ReturnDate = "Not Returned"
            };

            this.Add(rental);
        }
        public Rental ReturnCar(int carId)
        {
            Rental RentalToUpdate = this.Get(r => r.CarId == carId && r.ReturnDate == "Not Returned");
            if (RentalToUpdate != null)
            {
                RentalToUpdate.ReturnDate = DateTime.Now.ToString();
                this.Update(RentalToUpdate);
            }
            return RentalToUpdate;
        }
        public List<SpesificCarRentalDetail> GetCarRentDetail(int carId, Expression<Func<IDto, bool>> filter = null)
        {
            using (NorthwindContext context =  new NorthwindContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             select new SpesificCarRentalDetail
                             {
                                 BrandName = br.BrandName,
                                 CarId = c.Id,
                                 RentalId = r.Id,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                List<SpesificCarRentalDetail> CarRentDetails = new List<SpesificCarRentalDetail>();
                foreach (var r in result)
                {
                    if (r.CarId == carId)
                    {
                        CarRentDetails.Add(r);
                    }
                }
                return CarRentDetails;
            }
        }
       
        public List<SpesificCustomerRentalDetail> GetCustomerRentalDetails(int customerId, Expression<Func<IDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Customers
                             join r in context.Rentals
                             on c.Id equals r.CustomerId
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new SpesificCustomerRentalDetail
                             {
                                 CustomerId = c.Id,
                                 CustomerName = u.FirstName,
                                 RentalId = r.Id,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                List<SpesificCustomerRentalDetail> CustomerRentDetails = new List<SpesificCustomerRentalDetail>();
                foreach (var re in result)
                {
                    if (re.CustomerId == customerId)
                    {
                        CustomerRentDetails.Add(re);
                    }
                }
                return CustomerRentDetails;
            }
        }
       
    }
}

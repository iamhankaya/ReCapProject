using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDetailDal:EfEntityRepositoryBase<PaymentDetail,NorthwindContext>,IPaymentDetailDal
    {
        public void CreatePayment(int carId,int paymentAmount,int cardId, string description)
        {
            PaymentDetail paymentDetail = new PaymentDetail()
            {
                CarId = carId,
                PaymentAmount = paymentAmount,
                CardId = cardId,
                Description = description,
                PaymentDate = DateTime.Now.ToString()
            };
            this.Add(paymentDetail);

        }
    }
}

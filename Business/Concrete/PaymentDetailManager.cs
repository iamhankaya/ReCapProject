using Business.Abstract;
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
    public class PaymentDetailManager : IPaymentDetailService
    {
        IPaymentDetailDal _paymentDetailDal;
       

        public PaymentDetailManager(IPaymentDetailDal paymentDetailDal)
        {
            _paymentDetailDal = paymentDetailDal;
        }

        public IResult Add(PaymentDetail entity)
        {
            PaymentDetail paymentDetail = new PaymentDetail()
            {
                CardId = entity.CardId,
                CarId = entity.CarId,
                Description = entity.Description,
                PaymentAmount = entity.PaymentAmount,
                PaymentDate = DateTime.Now.ToString()
            };
            _paymentDetailDal.Add(paymentDetail);
            return new SuccessResult();
        }

        public IResult CreatePayment(int carId, int paymentAmount, int cardId, string description)
        {
            _paymentDetailDal.CreatePayment(carId, paymentAmount, cardId,description);
            return new SuccessResult();
        }

        public IResult Delete(PaymentDetail entity)
        {
            _paymentDetailDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<PaymentDetail>> GetAll()
        {
            return new SuccessDataResult<List<PaymentDetail>>(_paymentDetailDal.GetAll()); 
        }

        public IResult Update(PaymentDetail entity)
        {
            _paymentDetailDal.Update(entity);
            return new SuccessResult();
        }
    }
}

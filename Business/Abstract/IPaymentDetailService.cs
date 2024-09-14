using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentDetailService : IService<PaymentDetail>
    {
        IResult CreatePayment(int carId, int paymentAmount, int cardId, string description);
    }
}

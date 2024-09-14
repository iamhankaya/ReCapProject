using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService : IService<CreditCard>
    {
        IDataResult<CreditCard> Get(int id);

        IResult UpdateCardLimit(int cardNo, int paymentAmount);
    }
}

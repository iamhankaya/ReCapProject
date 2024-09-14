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
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, NorthwindContext>, ICreditCardDal
    {
        public void CredidCardLimitUpdate(int cardNo,int paymentAmount)
        {
            CreditCard creditCard = this.Get(p => p.CardNo == cardNo);
            if (creditCard != null)
            {
                creditCard.CardLimit = creditCard.CardLimit - paymentAmount;
                this.Update(creditCard);
            }
        }
    }
}

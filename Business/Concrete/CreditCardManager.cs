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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard entity)
        {
            _creditCardDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(CreditCard entity)
        {
            _creditCardDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<CreditCard> Get(int id)
        {

            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(p => p.CardNo == id));
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IResult Update(CreditCard entity)
        {
            _creditCardDal.Update(entity);
            return new SuccessResult();
        }

        public IResult UpdateCardLimit(int cardNo, int paymentAmount)
        {
            _creditCardDal.CredidCardLimitUpdate(cardNo, paymentAmount);
            return new SuccessResult();
        }
    }
}

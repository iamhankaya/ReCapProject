using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CardId { get; set; }
        public int CardNo { get; set; }
        public int CustomerId { get; set; }
        public int CardLimit { get; set; }
    }
}

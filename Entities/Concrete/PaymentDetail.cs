using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PaymentDetail: IEntity
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentDate { get; set; }

    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class RentalDetailDto :IDto
    {
        public string BrandName { get; set; }   
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
        public int CarId { get; set; }
        public int CustomerId   { get; set; }
    }
}

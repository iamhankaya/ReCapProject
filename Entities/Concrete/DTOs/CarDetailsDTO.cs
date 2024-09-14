using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class CarDetailsDTO : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }

        public int BrandId { get; set; }
        public int ColorId { get; set; }
       
    }
}

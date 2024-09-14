using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailsDTO> GetCarDetail(int? BrandId,int? ColorId,Expression<Func<CarDetailsDTO, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             
                             
                             select new CarDetailsDTO {BrandName = b.BrandName,ColorName = co.ColorName,Description = c.Description,DailyPrice=c.DailyPrice ,Id=c.Id,ModelYear=c.ModelYear,BrandId=b.BrandId,ColorId=c.ColorId};
                List<CarDetailsDTO> listedBrands = new List<CarDetailsDTO>();
                List<CarDetailsDTO> listedColors = new List<CarDetailsDTO>();
                if(BrandId != null)
                {
                    foreach(var r in result)
                    {
                        if (r.BrandId == BrandId)
                        {
                            listedBrands.Add(r);
                        }
                    }
                    return listedBrands;
                }

                if(ColorId != null)
                {
                    foreach(var r in result)
                    {
                        if(r.ColorId == ColorId)
                        {
                            listedColors.Add(r);
                        }
                    }
                    return listedColors;
                }

                return result.ToList();
                
                
            }
        }
    }
}

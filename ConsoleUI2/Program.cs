using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;
using System.Drawing;

CarManager carManager = new CarManager(new EfCarDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());
ColorManager colorManager = new ColorManager(new EfColorDal());

Brand brand = new Brand
{
    BrandId= 2,
    BrandName="Bmw"
};



Entities.Concrete.Color color = new Entities.Concrete.Color
{
    ColorId=2,
    ColorName="Blue"
};

Car car = new Car
{
    BrandId = 1,
    ColorId = 1,
    DailyPrice = 1000,
    Description = "Merce Benz",
    Id = 1,
    ModelYear = 2003
};


foreach (var car1 in carManager.GetCarDetails())
{
    Console.WriteLine(car1.BrandName+"/"+car1.ColorName+"/"+car1.DailyPrice+"/"+car1.Description);
}



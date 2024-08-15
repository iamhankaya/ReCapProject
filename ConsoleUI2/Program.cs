using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


CarManager carManager = new CarManager(new EfCarDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());
ColorManager colorManager = new ColorManager(new EfColorDal());
UserManager userManager = new UserManager(new EfUserDal());
CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
RentalManager rentalManager = new RentalManager(new EfRentalDal());

foreach (var customerDetail in rentalManager.GetCustomerRentalDetails(1).data)
{
    Console.WriteLine("Customer Id: " + customerDetail.CustomerId +
                      "Rental Id: " + customerDetail.RentalId +
                      "Customer Name: " + customerDetail.CustomerName +
                      "Rent Date: " + customerDetail.RentDate +
                      "Return Date: " + customerDetail.ReturnDate);
    Console.WriteLine("-------------------------------");
}
static void AddUserTest(UserManager userManager)
{
    User user = new User
    {
        Id = 1,
        FirstName = "Metehan",
        LastName = "Kaya",
        Email = "Test",
        Password = "Test"
    };

    userManager.Add(user);
    foreach (var item in userManager.GetAll().data)
    {
        Console.WriteLine(item.FirstName);
    }
}

static void CustomerTest(CustomerManager customerManager)
{
    Customer customer = new Customer
    {
        Id = 1,
        UserId = 1,
        CompanyName = "Test"
    };

    customerManager.Add(customer);

    foreach (var item in customerManager.GetAll().data)
    {
        Console.WriteLine(item.CompanyName);
    }
}

static void RentandReturnTest(RentalManager rentalManager)
{
    //rentalManager.RentCar(1, 1);
    //Console.WriteLine(rentalManager.RentCar(1, 1).Message);
    rentalManager.ReturnCar(1);
    Console.WriteLine(rentalManager.ReturnCar(1).Message);

    foreach (var r in rentalManager.GetAll().data)
    {
        Console.WriteLine("Rend Id: " + r.Id + "/" + "Customer Id: " + r.CustomerId + "/" + "Car Id: " + r.CarId + "/" + "Kiralama Tarihi: " + r.RentDate + "Geri Iade Tarihi: " + r.ReturnDate);
    }
}

static void GetCarDetail(RentalManager rentalManager)
{
    foreach (var carDetail in rentalManager.GetCarRentalDetails(1).data)
    {
        Console.WriteLine("Car Id: " + carDetail.CarId +
                          "Rental Id: " + carDetail.RentalId +
                          "Brand Name: " + carDetail.BrandName +
                          "Rent Date: " + carDetail.RentDate +
                          "Return Date: " + carDetail.ReturnDate);
        Console.WriteLine("-------------------------------");
    }
}
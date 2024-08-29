using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SuccessfullyAdded = "Nesne başarıyla eklendi";
        public static string SuccessfullyUpdated = "Nesne başarıyla güncellendi";
        public static string SuccessfullyDeleted = "Nesne başarıyla silindi";
        public static string CarsSuccessfullyListed = "Arabalar başarıyla listelendi";
        public static string BrandsSuccessfullyListed = "Markalar başarıyla listelendi";
        public static string ColorsSuccessfullyListed = "Renkler başarıyla listelendi";
        public static string InvalidCarDescription = "Araba açıklaması 2 karakterden büyük olmalıdır.";
        public static string SuccessfullyRented = "Araba başarıyla kiralanmıştır";
        public static string SuccessfullyReturned = "Araba başarıyla iade edilmiştir";
        public static string EmailAlreadyExists=  "Bu eposta zaten kullanılıyor";
        public static string ThisCarAlreadyReturned = "Bu arada zaten kiralanmamış";
        public static string ImageLimitExceded="Resim limiti aşıldı";
        public static string UserSuccessfullyRegistered="Kullanıcı başarıyla kayıt oldu";
        public static string PasswordInvalid="Şifre Yanlış";
        internal static string SuccessfulLogin="Oturum açıldı";
        internal static string AccessTokenCreated="Token başarıyla oluşturuldu";
        internal static string? AuthorizationDenied="Erişim reddedildi";
        internal static string UserNotFound="Kullanıcı bulunamadı";
        internal static string UserAlreadyExists="Kullanıcı zaten kayıtlı";
    }
}

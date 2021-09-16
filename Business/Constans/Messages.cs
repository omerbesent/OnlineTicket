
using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constans
{
    public class Messages
    {
        public static string EventsListed = "Etkinlikler listelendi";

        public static string EventAdded = "Etkinlik oluşturuldu";
        public static string EventUpdated = "Etkinlik güncellendi";
        public static string EventDeleted = "Etkinlik silindi";

        public static string SeatsListed = "Koltuklar listelendi";
        public static string SelectedSeatsAdded = "Seçilen koltuklar eklendi";
        public static string SelectedSeatsDeleted = "Seçilen koltuklar silindi";

        public static string AuthorizationDenied = "Yetkiniz yoktur";

        public static string UserRegistered = "Kullanıcı oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre yanlış";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}

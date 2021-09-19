
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

        public static string CategoriesListed = "Kategoriler listelendi";
        public static string CategoryAdded = "Kategori oluşturuldu";
        public static string CategoryUpdated = "Kategori güncellendi";
        public static string CategoryDeleted = "Kategori silindi";

        public static string PostersListed = "Posterler listelendi";
        public static string PosterAdded = "Poster oluşturuldu";
        public static string PosterUpdated = "Poster güncellendi";
        public static string PosterDeleted = "Poster silindi";

        public static string PlacesListed= "Mekanlar listelendi";
        public static string PlaceAdded = "Mekan oluşturuldu";
        public static string PlaceUpdated = "Mekan güncellendi";
        public static string PlaceDeleted = "Mekan silindi";

        public static string EmailSended = "Email gönderildi";
    }
}

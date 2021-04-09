using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BookAdded = "Kitap Eklendi";
        public static string BookDeleted = "Kitap Silindi";
        public static string BookExists = "Kitap zaten Bulunuyor";
        public static string BookUpdated = "Kitap Güncellendi";

        public static string UserRegistered = "Kullanıcı Kaydoldu";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Başarılı Giriş";

        public static string UserAlreadyExists = "Kullanıcı Zaten Bulunuyor";

        public static string AccessTokenCreated = "Jeton Üretildi";

        public static string AuthorizationDenied = "Erişim Yetkisi Bulunamadı";

        public static string RentalExists = "Bu Kitap Şu Anda Bulunmuyor";

        public static string RentalSucced = "Kiralama Başarılı";

        public static string RentalDeleted = "Sipariş İptal Edildi";

        public static string PublisherAdded = "Yayıncı Eklendi";

        public static string PublisherUpdated = "Yayınevi Güncellendi";
        public static string PublisherExists = "Yayınevi Zaten Bulunuyor";

        public static string AuthorAdded = "Yazar Eklendi";

        public static string AuthorExists = "Yazar Zaten Bulunuyor";
    }
}

using Core.Entities.Concrete;
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
        public static string ProductAdded = "Ürün eklendi!";
        public static string ProductNameInvalid = "Ürün ismi geçersiz!";
        public static string MaintenanceTime = "Sistem Bakımda!";
        public static string ProductListed = "Ürünler listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        internal static string ProductNameAllReadyExists = "Bu isimde bir ürün halihazırda bulunmakta.";
        internal static string CategoryLimitExceeded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor.";
        internal static string AuthorizationDenied ="Yetkiniz yok!";
        internal static string UserRegistered="Kullanıcı kaydedildi";

        

        internal static string UserAlreadyExists="Kullanıcı zaten mevcut";
        internal static string AccessTokenCreated="Token oluşturuldu";

        

        public static string SuccessfulLogin="Giriş Başarılı";
        internal static string UserNotFound = "Kullanıcı bulunamadı!";
        internal static string PasswordError = "Parola Hatası";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string CategoryAdded = "Kategori Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string UnitPriceInvalid = "Birim Fiyatı Geçersiz";
        
        public static string ProductCountOfCategoryError = "Bir Kategoride En Fazla 10 Ürün Olabilir.";

        public static string ProductNameAlreadyExists = "Böyle Bir İsimde Ürün var";
        public static string CategoryLimitExceded = "Kategori Sınırı Aşıldı";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";

        public static string CategoryDeleted = "Kategori başarıyla silindi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string UserAdded = "Kullanici basariyla eklendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string UnAuthorized = "Önce giriş yapmanız gerek";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
        public static string Added = "Eklendi basarıyla";
        public static string Listed = "Listelendi basariyla";
        public static string NotListed = "Basarisiz listeleme";
        public static string Updated = "Güncellendi basariyla";
        public static string Deleted = "Silindii basariyla";
        public static string TcIdAlreadyExists = "Aynı TC De biri var zaten ";
        public static string SameDateTimeDoctorAlreadyExists = "Aynı gün ve saate aynı doktora randevunuz bulunmaktadır. ";
        public static string IsNotVerification = "Maile göndrilen kod uyuşmuyor ";
        public static string SuccessVerification = "Doğrulama Başarlı ";
        public static string InvalidToken="Geçersiz Token, Süresi Geçmiş işlem yada başka biri randevu almış olabilir.";

    }

}

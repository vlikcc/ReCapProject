using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem Bakımda.";

        public static string CarAdded = "Araçlar Eklendi.";
        public static string CarListed = "Araçlar Listelendi.";
        public static string CarInvalid = "Geçersiz Araç Adı.Araç Adı En Az İki Karakter Olmalıdır.";
        public static string CarDeleted = "Araç Silindi.";
        public static string CarUpdated = "Araç Güncellendi.";

        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerDeleted = "Müşteri Silindi.";
        public static string CustomerUpdated = "Müsteri Güncellendi.";

        public static string RentalAdded = "Kiralama Eklendi.";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalUpdated = "Kiralama Güncellendi.";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserUpdated = "Kullanıcı Güncellendi";      

        public static string CarImageLimitExceeded = "Bir Araca en fazla 5 adet resim eklenebilir.";
    }
}

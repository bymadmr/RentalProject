using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Message
    {
        public static string Added = "Ekleme işlemi tamamlandı";
        public static string Deleted = "Silme işlemi tamamlandı";
        public static string Updated = "Güncelleme işlemi tamamlandı";
        public static string CarNameLenghtError = "Araç adı 2 karakterden az olamaz";
        public static string CarDailyPriceError = "Günlük araç fiyatı hatası";
        public static string Listened = "Listeleme tamamlandı";
        public static string CarNotAvailable = "Araç kiralamaya uygun değil";
    }
}

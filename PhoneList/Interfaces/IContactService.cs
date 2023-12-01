using PhoneList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList.Interfaces
{
    public interface IContactService
    {
        // Kişi eklemek için metod
        // Bu metod, rehber listesine yeni bir kişi ekler
        void AddContact();

        // Kişiyi isim ve soyisim kullanarak rehber listesinden silmek için metod
        // Bu metod, belirtilen isim ve soyisme sahip kişiyi rehberden siler
        void DeleteContact();

        // Rehber listesindeki bir kişinin detaylarını güncellemek için metod
        // Bu metod, mevcut bir kişinin ayrıntılarını günceller
        void UpdateContact();

        // Tüm rehberi listelemek için metod
        // Bu metod, rehberdeki tüm kişilerin listesini görüntüler
        void ListContacts();

        // Rehberde bir kişiyi isim ve soyisime göre aramak için metod
        // Bu metod, belirtilen isim ve soyisme sahip kişiyi rehberde arar
        void SearchContact();
    }


}

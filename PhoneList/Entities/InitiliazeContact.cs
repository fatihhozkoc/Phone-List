using PhoneList.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList.Entities
{
    public class InitiliazeContact
    {
        // Uygulama ilk çalıştığı zaman rehbere beş kişinin eklenmesini sağlayan metod 
        public void Initiliaze()
        {
            PhoneListManager phoneListManager = new PhoneListManager();
            List<Person> initialContacts = new List<Person>
            {
                new Person("Fatih", "Özkoç", "05001112233"),
                new Person("Betül", "Tekçe", "05001112234"),
                new Person("Mehmet", "Çelik", "05001112235"),
                new Person("Fatma", "Demir", "05001112236"),
                new Person("Ali", "Kaya", "05001112237")
            };

            // Her bir kişiyi rehber listesine ekle
            foreach (var person in initialContacts)
            {
                phoneListManager.Add(person);
            }
        }

    }
}

using PhoneList.Entities;
using PhoneList.Interfaces;
using PhoneList.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList.Manager
{
    public class PhoneListManager : IContactService
    {

        // Başlangıç olarak 5 kişinin eklenmesi 
        public void InitiliazeContact()
        {
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
                contacts.Add(person);
            }
        }

        private List<Person> contacts = new List<Person>();

        // İsme Göre Arama Yapılmasını Sağlayan Metod
        private void SearchByName()
        {
            // Kullanıcıdan aranacak kişinin adını al
            string firstName = Utilities.Utilities.GetInput("Aranacak kişinin adını giriniz: ");
            // Kullanıcıdan aranacak kişinin soyadını al
            string lastName = Utilities.Utilities.GetInput("Aranacak kişinin soyadını giriniz: ");

            // Ad ve soyada göre rehberde arama yap ve sonucu al
            // StringComparison.OrdinalIgnoreCase, büyük/küçük harf duyarlılığını yok sayar
            var result = contacts.FirstOrDefault(p =>
                p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            // Eğer sonuç varsa (yani aranan ad ve soyada sahip bir kişi varsa)
            if (result != null)
            {
                // Bulunan kişinin bilgilerini ekrana yazdır
                Console.WriteLine($"Bulunan Kişi: {result.FirstName} {result.LastName}, Telefon: {result.PhoneNumber}");
            }
            else
            {
                // Eğer sonuç yoksa (yani aranan ad ve soyada sahip bir kişi yoksa)
                // Kullanıcıya aranan kriterlere uygun kişinin olmadığını bildir
                Console.WriteLine("Aranan kriterlere uygun kişi bulunamadı.");
            }
        }

        // Telefon Numarasına Göre Arama Yapılmasını Sağlayan Metod
        private void SearchByPhoneNumber()
        {
            // Kullanıcıdan aranacak telefon numarasını al
            string phoneNumber = Utilities.Utilities.GetInput("Aranacak telefon numarasını giriniz: ");

            // Telefon numarasına göre rehberde arama yap ve sonucu al
            var result = contacts.FirstOrDefault(p => p.PhoneNumber == phoneNumber);

            // Eğer sonuç varsa (yani aranan telefon numarasına sahip bir kişi varsa)
            if (result != null)
            {
                // Bulunan kişinin bilgilerini ekrana yazdır
                Console.WriteLine($"Bulunan Kişi: {result.FirstName} {result.LastName}, Telefon: {result.PhoneNumber}");
            }
            else
            {
                // Eğer sonuç yoksa (yani aranan numaraya sahip bir kişi yoksa)
                // Kullanıcıya aranan kriterlere uygun kişinin olmadığını bildir
                Console.WriteLine("Aranan kriterlere uygun kişi bulunamadı.");
            }
        }

        // Ekleme İşlemlerinin Yapılmasını Sağlayan Metod
        public void AddContact()
        {
            // Yeni kişinin adını kullanıcıdan al
            string firstName;
            do
            {
                firstName = Utilities.Utilities.GetInput("Lütfen kişinin adını giriniz: ");
                // Girilen adın geçerli olup olmadığını kontrol et
                if (!Utilities.Utilities.IsValidName(firstName))
                {
                    Console.WriteLine("Geçersiz format. Lütfen yalnızca harfler içeren bir ad giriniz.");
                }
            } while (!Utilities.Utilities.IsValidName(firstName)); // Geçersiz isim girildiyse tekrar al

            // Yeni kişinin soyadını kullanıcıdan al
            string lastName;
            do
            {
                lastName = Utilities.Utilities.GetInput("Lütfen kişinin soyadını giriniz: ");
                // Girilen soyadın geçerli olup olmadığını kontrol et
                if (!Utilities.Utilities.IsValidName(lastName))
                {
                    Console.WriteLine("Geçersiz format. Lütfen yalnızca harfler içeren bir soyad giriniz.");
                }
            } while (!Utilities.Utilities.IsValidName(lastName)); // Geçersiz soyad girildiyse tekrar al

            // Yeni kişinin telefon numarasını kullanıcıdan al
            string phoneNumber;
            do
            {
                phoneNumber = Utilities.Utilities.GetInput("Lütfen kişinin telefon numarasını giriniz: ");
                // Girilen telefon numarasının geçerli olup olmadığını kontrol et
                if (!Utilities.Utilities.IsValidPhoneNumber(phoneNumber))
                {
                    Console.WriteLine("Geçersiz telefon numarası. Lütfen 11 haneli bir numara giriniz.");
                }
            } while (!Utilities.Utilities.IsValidPhoneNumber(phoneNumber)); // Geçersiz telefon numarası girildiyse tekrar al

            // Yeni kişi nesnesi oluştur ve rehbere ekle
            Person newPerson = new Person(firstName, lastName, phoneNumber);
            contacts.Add(newPerson);
            //phoneListManager.Add(newPerson);

            // Ekleme işleminin tamamlandığını kullanıcıya bildir
            Console.WriteLine($"{firstName} {lastName} rehbere eklendi.");
        }

        // Silme İşlemlerini Yapılmasını Sağlayan Metod
        public void DeleteContact()
        {
            // Silinecek kişinin adını kullanıcıdan al
            string firstName;
            do
            {
                firstName = Utilities.Utilities.GetInput("Silinecek kişinin adını giriniz: ");
                // Girilen adın geçerli olup olmadığını kontrol et
                if (!Utilities.Utilities.IsValidName(firstName))
                {
                    Console.WriteLine("Geçersiz ad. Lütfen yalnızca harfler içeren bir ad giriniz.");
                }
            } while (!Utilities.Utilities.IsValidName(firstName));

            // Silinecek kişinin soyadını kullanıcıdan al
            string lastName;
            do
            {
                lastName = Utilities.Utilities.GetInput("Silinecek kişinin soyadını giriniz: ");
                // Girilen soyadın geçerli olup olmadığını kontrol et
                if (!Utilities.Utilities.IsValidName(lastName))
                {
                    Console.WriteLine("Geçersiz soyad. Lütfen yalnızca harfler içeren bir soyad giriniz.");
                }
            } while (!Utilities.Utilities.IsValidName(lastName));

            // Rehberde bu isim ve soy isme sahip kişiyi ara
            Person personToDelete = contacts.FirstOrDefault(p =>p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
            p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));


            // Kişi rehberde bulunursa silme işlemi için onay iste
            if (personToDelete != null)
            {
                Console.WriteLine($"{firstName} {lastName} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                string confirmation = Console.ReadLine().Trim().ToLower();

                // Onay alınırsa kişiyi sil ve kullanıcıya bilgi ver
                if (confirmation == "y")
                {
                    var person = contacts.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
                    if (person != null)
                    {
                        contacts.Remove(person);
                    }
                    Console.WriteLine($"{firstName} {lastName} rehberden silindi.");
                }
                // Onay verilmezse işlemi iptal et ve bilgi ver
                else if (confirmation == "n")
                {
                    Console.WriteLine($"{firstName} {lastName} rehberden silinmedi.");
                }
                // Geçersiz bir giriş yapılırsa işlemi iptal et ve bilgi ver
                else
                {
                    Console.WriteLine("Geçersiz giriş. İşlem iptal edildi.");
                }
            }
            // Aranan kişi rehberde bulunamazsa kullanıcıya bilgi ver
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.");
            }
        }

        // Güncelleme İşlemlerinin Yapılmasını Sağlayan Metod
        public void UpdateContact()
        {
            while (true)
            {
                // Güncellenecek kişinin adını kullanıcıdan al
                string firstName = Utilities.Utilities.GetInput("Güncellenecek kişinin adını giriniz: ");
                // Girilen adın geçerli olup olmadığını kontrol et
                if (!Utilities.Utilities.IsValidName(firstName))
                {
                    Console.WriteLine("Geçersiz ad. Lütfen yalnızca harfler içeren bir ad giriniz.");
                    continue; // Geçersiz giriş durumunda döngünün başına dön
                }

                // Güncellenecek kişinin soyadını kullanıcıdan al
                string lastName = Utilities.Utilities.GetInput("Güncellenecek kişinin soyadını giriniz: ");
                // Girilen soyadın geçerli olup olmadığını kontrol et
                if (!Utilities.Utilities.IsValidName(lastName))
                {
                    Console.WriteLine("Geçersiz soyad. Lütfen yalnızca harfler içeren bir soyad giriniz.");
                    continue; // Geçersiz giriş durumunda döngünün başına dön
                }

                // Rehberde bu isim ve soy isme sahip kişiyi ara
                Person personToUpdate = contacts.FirstOrDefault(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

                // Kişi rehberde bulunursa güncelleme işlemini yap
                if (personToUpdate != null)
                {
                    // Yeni telefon numarasını kullanıcıdan al
                    string newPhoneNumber = Utilities.Utilities.GetInput("Yeni telefon numarasını giriniz: ");
                    // Girilen telefon numarasının geçerli olup olmadığını kontrol et
                    if (!Utilities.Utilities.IsValidPhoneNumber(newPhoneNumber))
                    {
                        Console.WriteLine("Geçersiz telefon numarası. Lütfen 11 haneli bir numara giriniz.");
                        continue; // Geçersiz giriş durumunda döngünün başına dön
                    }

                    // Telefon numarasını güncelle ve kullanıcıya bilgi ver
                    personToUpdate.PhoneNumber = newPhoneNumber;
                    Console.WriteLine($"{firstName} {lastName} kişisinin telefon numarası güncellendi.");
                    break; // İşlem tamamlandı, döngüden çık
                }
                else
                {
                    // Aranan kişi bulunamazsa kullanıcıya bilgi ver ve seçenek sun
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("1. Güncellemeyi sonlandırmak için");
                    Console.WriteLine("2. Yeniden denemek için");

                    // Kullanıcının seçimini al
                    int choice = Utilities.Utilities.ShowMenu(new string[] { "Güncellemeyi sonlandırmak için", "Yeniden denemek için" });
                    // Eğer kullanıcı güncellemeyi sonlandırmak isterse döngüden çık
                    if (choice == 1)
                    {
                        break;
                    }
                    // Aksi halde döngü yeniden başlar ve kullanıcıdan bilgiler tekrar alınır
                }
            }
        }

        // Listeleme İşlemlerinin Yapılmasını Sağlayan Metod
        public void ListContacts()
        {
            // Sıralama türü için kullanıcıdan seçim al
            int sortChoice = Utilities.Utilities.ShowMenu(new string[] { "A-Z'ye göre sırala", "Z-A'ya göre sırala" });

            // Rehberdeki tüm kişileri al
            var allContacts = this.contacts;

            // Seçilen sıralama türüne göre listeyi sırala
            if (sortChoice == 1)
            {
                allContacts = allContacts.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList();
            }
            else if (sortChoice == 2)
            {
                allContacts = allContacts.OrderByDescending(p => p.FirstName).ThenByDescending(p => p.LastName).ToList();
            }

            // Eğer rehber boşsa kullanıcıya bilgi ver
            if (allContacts.Count == 0)
            {
                Console.WriteLine("Rehberde hiçbir kayıt bulunamadı.");
                //return;
            }

            // Rehberdeki her kişi için bilgileri belirtilen formatta yazdır
            foreach (var person in allContacts)
            {
                Console.WriteLine($"İsim: {person.FirstName} Soyisim: {person.LastName} Telefon Numarası: {person.PhoneNumber}");
            }
        }

        // Arama İşlemlerinin Yapılmasını Sağlayan Metod
        public void SearchContact()
        {
            // Kullanıcıya arama türü seçimi için bilgi ver
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("**************************************");

            // Kullanıcıdan arama türü seçimi almak için menü göster
            // Menüde isim/soyisim veya telefon numarasına göre arama seçenekleri sunuluyor
            int choice = Utilities.Utilities.ShowMenu(new string[] { "İsim veya soyisime göre arama", "Telefon numarasına göre arama" });

            // Kullanıcının seçimine göre ilgili arama fonksiyonunu çağır
            switch (choice)
            {
                case 1:
                    // İsim veya soyisime göre arama yapılacaksa ilgili fonksiyonu çağır
                    SearchByName();
                    break;
                case 2:
                    // Telefon numarasına göre arama yapılacaksa ilgili fonksiyonu çağır
                    SearchByPhoneNumber();
                    break;
            }
        }

    }
}

using PhoneList.Entities;
using PhoneList.Manager;
using PhoneList.Utilities;

internal class Program
{
    static PhoneListManager phoneListManager = new PhoneListManager();
    private static void Main(string[] args)
    {
        while (true)
        {
            //Console.Clear();
            Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz");
            Console.WriteLine("****************************************");
            string[] options = { "Telefon Numarası Kaydet", "Telefon Numarası Sil", "Telefon Numarası Güncelle", "Rehber Listeleme", "Rehberde Arama", "Çıkış" };
            int choice = Utilities.ShowMenu(options);

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    phoneListManager.AddContact();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Clear();
                    phoneListManager.DeleteContact();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Clear();
                    phoneListManager.UpdateContact();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Telefon Rehberi");
                    phoneListManager.ListContacts();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Clear();
                    phoneListManager.SearchContact();
                    Console.WriteLine();
                    break;
                case 6:
                    return;
            }
        }
    }
}
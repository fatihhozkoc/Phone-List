using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList.Utilities
{
    public class Utilities
    {
        // Input almak İçin Metod
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        
        // Menüyü Listelemek İçin Metod
        public static int ShowMenu(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.Write("Seçiminizi yapınız: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > options.Length)
            {
                Console.Write("Geçersiz seçim. Lütfen tekrar deneyiniz: ");
            }

            return choice;
        }

        // İsim geçerliliğini kontrol etmek için metod
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }

        // Telefon numarası geçerliliğini kontrol etmek için metod
        public static bool IsValidPhoneNumber(string number)
        {
            // Örnek olarak 10 haneli bir numara varsayılmıştır
            return !string.IsNullOrWhiteSpace(number) && number.All(char.IsDigit) && number.Length == 11;
        }


    }
}

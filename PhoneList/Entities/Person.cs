using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList.Entities
{
    public class Person
    {
        // Kişinin adını tutar
        public string FirstName { get; set; }

        // Kişinin soyadını tutar
        public string LastName { get; set; }

        // Kişinin telefon numarasını tutar
        public string PhoneNumber { get; set; }

        // Constructor
        public Person(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}

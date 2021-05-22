using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class UserDetailsViewModel : UserViewModel
    {
        [DisplayName("Imię")]
        public string FirstName { get; set; }

        [DisplayName("Drugie imię")]
        public string SecondName { get; set; }

        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

        [DisplayName("Numer kontaktowy")]
        public string ContactNumber { get; set; }

        [DisplayName("Konto potwierdzone")]
        public bool IsConfirmed { get; set; }

        [DisplayName("PESEL")]
        public string PESEL { get; set; }

        public string Place { get; set; }
        public string Prefix { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string PostOfficePlace { get; set; }
        public List<int> RelationsId { get; set; }

        public UserDetailsViewModel()
        {

        }

        public UserDetailsViewModel(string firstName, string secondName, string surname, string contactNumber, bool isConfirmed, string pesel, string place,
                                       string prefix, string street, string houseNumber, string apartmentNumber, string postalCode, string postOfficePlace)
        {
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
            ContactNumber = contactNumber;
            IsConfirmed = isConfirmed;
            PESEL = pesel;
            Place = place;
            Prefix = prefix;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
            PostalCode = postalCode;
            PostOfficePlace = postOfficePlace;
        }
    }
}

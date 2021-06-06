using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Models
{
    public class UserDetailsModel : UserModel
    {
        public string FirstName       { get; set; }
        public string SecondName      { get; set; }
        public string Surname         { get; set; }
        public string ContactNumber   { get; set; }
        public string PESEL           { get; set; }
        public bool IsConfirmed       { get; set; }
        public string Place           { get; set; }
        public string Prefix          { get; set; }
        public string Street          { get; set; }
        public string HouseNumber     { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode      { get; set; }
        public string PostOfficePlace { get; set; }

        public UserDetailsModel() { }

        public UserDetailsModel(string firstName, string secondName, string surname)
        {
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
        }

        public UserDetailsModel(string firstName, string secondName, string surname, string contactNumer, string pesel, bool isConfirmed, string place,
                                string prefix, string street, string houseNumber, string apartmentNumber, string postalCode, string postOfficePlace)
        {
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
            ContactNumber = contactNumer;
            PESEL = pesel;
            IsConfirmed = isConfirmed;
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

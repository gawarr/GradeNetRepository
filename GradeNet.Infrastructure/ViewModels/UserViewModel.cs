using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class UserViewModel
    {
        [DisplayName("Email")]
        [MinLength(6, ErrorMessage = "Minimalna długość znaków 6.")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość znaków 32.")]
        [Required(ErrorMessage = "* Pole jest wymagane!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Hasło")]
        [MinLength(5, ErrorMessage = "Minimalna długość znaków 5.")]
        [MaxLength(32, ErrorMessage = "Maksymalna długość znaków 32.")]
        [Required(ErrorMessage = "* Pole jest wymagane!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Powtórz hasło")]
        [MinLength(5, ErrorMessage = "Minimalna długość znaków 5.")]
        [MaxLength(32, ErrorMessage = "Maksymalna długość znaków 32.")]
        [Required(ErrorMessage = "* Pole jest wymagane!")]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }

        public UserViewModel()
        {
               
        }

        public UserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

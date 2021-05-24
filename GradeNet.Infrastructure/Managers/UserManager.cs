using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using GradeNet.Infrastructure.Helpers;
using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.Repositories;
using GradeNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
        }

        public UserViewModel GetUser(int userId)
        {
            try
            {
                var user = _userRepository.GetUser(userId);
                UserViewModel model = new UserViewModel(user.Email, user.Password);

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool CheckLoginDetails(UserViewModel model)
        {
            UserModel user = new UserModel(model.Email, UserHelper.MD5Hash(model.Password));

            return _userRepository.CheckLoginDetails(user);
        }

        public void LastSuccessfulLoginSet(string email) =>
            _userRepository.LastSuccessfulLoginSet(email);

        public UserDetailsViewModel GetUserDetails(string email)
        {
            try
            {
                UserDetailsModel user = _userRepository.UserDetailsGet(email);
                UserDetailsViewModel viewModel = new UserDetailsViewModel(user.FirstName, user.SecondName, user.Surname, user.ContactNumber, user.IsConfirmed, user.PESEL, user.Place, 
                                                                          user.Prefix, user.Street, user.HouseNumber, user.ApartmentNumber, user.PostalCode, user.PostOfficePlace);
                return viewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

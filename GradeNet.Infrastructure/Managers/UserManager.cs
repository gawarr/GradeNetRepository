using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using GradeNet.Infrastructure.Helpers;
using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.Repositories;
using GradeNet.Infrastructure.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Managers
{
    public class UserManager : IUserManager
    {
        private static Logger logger = LogManager.GetLogger("loggerRole");
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
                logger.Error($"GetUser(int {userId}) - {ex}.");
                return new UserViewModel();
            }
        }

        public bool CheckLoginDetails(UserViewModel model)
        {
            UserModel user = new UserModel(model.Email, UserHelper.MD5Hash(model.Password));

            logger.Debug($"Rozpoczynam sprawdzanie danych logowania dla {user.Email}.");
             bool flag =_userRepository.CheckLoginDetails(user);
            logger.Debug($"Test sprawdzania danych logowania dla {user.Email} zakończony.");

            return flag;
        }

        public void LastSuccessfulLoginSet(string email) =>
            _userRepository.LastSuccessfulLoginSet(email);

        public UserDetailsViewModel GetUserDetails(string email)
        {
            try
            {
                logger.Debug($"Rozpoczynam pobieranie danych dla {email}.");
                UserDetailsModel user = _userRepository.UserDetailsGet(email);
                UserDetailsViewModel viewModel = new UserDetailsViewModel(user.FirstName, user.SecondName, user.Surname, user.ContactNumber, user.IsConfirmed, user.PESEL, user.Place, 
                                                                          user.Prefix, user.Street, user.HouseNumber, user.ApartmentNumber, user.PostalCode, user.PostOfficePlace);
                logger.Debug($"Zakończone pobieranie danych dla {email}.");
                return viewModel;
            }
            catch (Exception ex)
            {
                logger.Error($"GetUserDetails(string {email}) - {ex}.");
                return new UserDetailsViewModel();
            }
        }
    }
}

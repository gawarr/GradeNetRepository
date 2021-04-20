using GradeNet.Core.Interfaces;
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
                UserViewModel model = new UserViewModel()
                {
                    Email = user.Email,
                    Password = user.Password
                };

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

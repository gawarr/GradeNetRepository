using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserModel GetUser(int userId)
        {
            var user = new UserModel();

            try
            {
                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.UserGet(userId).FirstOrDefault();

                    user.Email = result.Email;
                    user.Password = result.Password;
                }

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

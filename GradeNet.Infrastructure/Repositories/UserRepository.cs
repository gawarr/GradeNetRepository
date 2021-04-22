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
            try
            {
                UserModel user;
                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.UserGet(userId).FirstOrDefault();

                    user = new UserModel(result.Email, result.Password);
                }
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool CheckLoginDetails(UserModel user)
        {
            try
            {
                bool isCorrrect;
                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = Convert.ToBoolean(context.CheckLoginDetails(user.Email, user.Password).FirstOrDefault());

                    isCorrrect = result;
                }
                return isCorrrect;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

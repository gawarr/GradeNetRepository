using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static Logger logger = LogManager.GetLogger("loggerRole");
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
                logger.Error($"GetUser(int {userId}) - {ex}.");
                return new UserModel();
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
                logger.Error($"CheckLoginDetails() - {ex}.");
                return false;
            }
        }

        public void LastSuccessfulLoginSet(string email)
        {
            try
            {
                using(GradeNet_Entities context = new GradeNet_Entities())
                    context.LastSuccessfulLoginSet(email);
            }
            catch (Exception ex)
            {
                logger.Error($"LastSuccessfulLoginSet(string {email}) - {ex}.");
            }
        }

        public UserDetailsModel UserDetailsGet(string email)
        {
            try
            {
                UserDetailsModel user;
                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.UserDetailsGet(email).FirstOrDefault();

                    user = new UserDetailsModel(result.FirstName, result.SecondName, result.Surname, result.ContactNumber, result.PESEL, result.IsConfirmed, result.Place, result.Prefix,
                                                result.Street, result.HouseNumber, result.ApartmentNumber, result.PostalCode, result.PostOfficePlace);
                }
                return user;
            }
            catch (Exception ex)
            {
                logger.Error($"UserDetailsGet(string {email}) - {ex}.");
                return new UserDetailsModel();
            }
        }
    }
}

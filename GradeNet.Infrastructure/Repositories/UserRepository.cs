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
                //throw;
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
                throw;
            }
        }

        public string MainRoleOfUserGet(string email)
        {
            try
            {
                string role = String.Empty;
                using(GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.MainRolesOfUserGet(email).ToList();

                    if (result.Count == 1)
                        role = result[0];
                    else
                    {
                        throw new Exception($"Błąd pobierania przypisanych ról głównych dla użytkownika : {email}.");
                    }
                }
                return role;
            }
            catch (Exception ex)
            {
                throw;
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
                throw;
            }
        }
    }
}

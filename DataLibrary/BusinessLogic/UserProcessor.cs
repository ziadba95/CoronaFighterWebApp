using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        public static int CreateUser(string fName, string lName, string email, string password, DateTime dob, string gender, string roleType)
        {
            UserModel data = new UserModel
            {
                FirstName = fName,
                LastName = lName,
                Email = email,
                Password = password,
                Dob = dob,
                Gender = gender,
                RoleType = roleType
            };
            string sql = @"insert into dbo.[User] (fName, lName, gender, email, pass, DOB, roleType)
                                  values(@FirstName, @LastName, @Gender, @Email, @Password, @Dob, @RoleType);"; 
            return DAO.SaveData(sql, data);
        }
        public static List<UserModel> LoadUsers()
        {
            string sql = @"select  fName, lName, gender, email, roleType
                              from dbo.[User];";
            return DAO.LoadData<UserModel>(sql);
        }
    }
}

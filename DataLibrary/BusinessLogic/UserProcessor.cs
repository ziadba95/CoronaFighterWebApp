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
        public static int ChangePassword(string password,string userID)
        {
            UserModel data = new UserModel
            {
                Password = password,
            };
            string sql = @"UPDATE  dbo.[User] set pass='" + @password + "'where userID= '" + @userID + "'";
            return DAO.SaveData(sql, data);
        }
        public static int CreateDoctor(string fName, string lName, string email, string password, DateTime dob, string gender,string appStatus,string subDate)
        {
            DoctorModel data = new DoctorModel
            {
                FirstName = fName,
                LastName = lName,
                Email = email,
                Password = password,
                Dob = dob,
                Gender = gender,
                //Document=doc,
                AppStatus= appStatus,
                ApplicationDate = subDate
            };
            string sql = @"insert into dbo.[Applications] (firstName, lastName, gender, email, password, dob, appStatus,subDate)
                                  values(@FirstName, @LastName, @Gender, @Email, @Password, @Dob, @AppStatus,@ApplicationDate);";
            return DAO.SaveData(sql, data);
        }
        public static List<UserModel> LoadUsers()
        {
            string sql = @"select  fName, lName, gender, email, roleType from dbo.[User];";
            return DAO.LoadData<UserModel>(sql);
        }
        public static List<DoctorModel> LoadDoctorsWaiting()
        {
            string sql = @"select  appID,firstName,lastName,email,subDate,appStatus,gender,password,dob from dbo.[Applications] where appStatus='waiting';";
            return DAO.LoadData<DoctorModel>(sql);
        }
        public static bool LogIn(string email, string password)
        {
            //string sql = @"select count(userID) from dbo.[User] where email='@email' and pass='@password' ;";
            string sql = @"select count(userID) from dbo.[User] where email='" + @email + "'and pass= '" + @password + "'";

            return DAO.GetData(sql);
        }
        public static bool AdminLogIn(string email, string password)
        {
            //string sql = @"select count(userID) from dbo.[User] where email='@email' and pass='@password' ;";
            string sql = @"select count(adminID) from dbo.[Admin] where email='" + @email + "'and password= '" + @password + "'";

            return DAO.GetData(sql);
        }
        public static bool CheckDup(string email)
        {
            string sql = @"select count(userID) from dbo.[User] where email='" + @email + "'";

            return DAO.GetData(sql);
        }
        public static string GetFName(string email)
        {
            string sql = @"select fName from dbo.[User] where email='" + @email + "'";

            return DAO.GetUserName(sql);
        }
        public static string GetLName(string email)
        {
            string sql = @"select lName from dbo.[User] where email='" + @email + "'";

            return DAO.GetUserName(sql);
        }
        public static string GetUserID(string email)
        {
            string sql = @"select userID from dbo.[User] where email='" + @email + "'";

            return DAO.GetUserName(sql);
        }
        public static string GetRoleType(string email)
        {
            string sql = @"select roleType from dbo.[User] where email='" + @email + "'";

            return DAO.GetUserName(sql);
        }
    }
}
 
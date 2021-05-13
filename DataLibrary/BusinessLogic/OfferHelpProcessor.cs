using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class OfferHelpProcessor
    {
        public static int CreateOfferHelp(string UserID, string UserName, string HelpDescription, DateTime HelpDate, DateTime HelpTime, string FreeHour, string Contact, string HelpTitle,string City)
        {
            OfferHelpModel data = new OfferHelpModel
            {
                UserID = UserID,
                UserName = UserName,
                HelpDescription = HelpDescription,
                HelpDate = HelpDate,
                HelpTime = HelpTime,
                FreeHour = FreeHour,
                Contact = Contact,
                HelpTitle= HelpTitle,
                City=City,
            };
            string sql = @"insert into dbo.[OfferHelp] (userID, userName, helpDescription,helpDate,helpTime,freeHour,Contact,helpTitle,city)
                                  values(@UserID, @UserName,@HelpDescription ,@HelpDate,@HelpTime,@FreeHour,@Contact,@HelpTitle,@City);";
            return DAO.SaveData(sql, data);
        }
        public static List<OfferHelpModel> LoadOfferHelp()
        {
            string sql = @"select userID, userName, helpDescription,helpDate,helpTime,freeHour,Contact,helpTitle,city
                              from dbo.[OfferHelp];";
            return DAO.LoadData<OfferHelpModel>(sql);
        }
        public static List<OfferHelpModel> LoadOfferHelpByUser(string UserID)
        {
            string sql = @"select  userID, userName, helpDescription,helpDate,helpTime,freeHour,Contact,helpTitle,city
                              from dbo.[OfferHelp] where userID=" + @UserID;
            return DAO.LoadData<OfferHelpModel>(sql);
        }
        public static int DeleteOfferHelps(string HelpTitle)
        {
            OfferHelpModel data = new OfferHelpModel
            {
                HelpTitle = HelpTitle,
            };
            string sql = @"delete from dbo.[OfferHelp] where helpTitle ='" + @HelpTitle + "'";

            return DAO.SaveData(sql, data);
        }
        public static bool CheckDupH(string HelpTitle)
        {
            string sql = @"select count(helpTitle) from dbo.[OfferHelp] where helpTitle='" + @HelpTitle + "'";

            return DAO.GetData(sql);
        }
    }
}

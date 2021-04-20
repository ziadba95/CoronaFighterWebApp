using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class GroupProcessor
    {
        public static int CreateGroup(string groupName, string groupTime, string groupCreater, string userID)
        {
            GroupModel data = new GroupModel
            {
                GroupName = groupName,
                GroupTime = groupTime,
                GroupCreater = groupCreater,
                UserID = userID,
            };
            string sql = @"insert into dbo.[Group] (groupName, groupTime, groupCreater,userID)
                                  values(@GroupName, @GroupTime,@GroupCreater,@UserID);";
            return DAO.SaveData(sql, data);
        }
        public static List<GroupModel> LoadGroups()
        {
            string sql = @"select  groupName, groupTime, groupCreater,userID
                              from dbo.[Group];";
            return DAO.LoadData<GroupModel>(sql);
        }
        public static string GetGroupID(string groupName)
        {
            string sql = @"select groupID from dbo.[Group] where groupName='" + @groupName + "'";

            return DAO.GetUserName(sql);
        }
        public static bool CheckDupG(string groupName)
        {
            string sql = @"select count(groupName) from dbo.[Group] where groupName='" + @groupName + "'";

            return DAO.GetData(sql);
        }
       
    }
}

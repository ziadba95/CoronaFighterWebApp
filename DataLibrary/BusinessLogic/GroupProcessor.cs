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
        public static int CreateGroup(string groupName, string groupTime, string groupCreater, string userID,string city,string description)
        {
            GroupModel data = new GroupModel
            {
                GroupName = groupName,
                GroupTime = groupTime,
                GroupCreater = groupCreater,
                UserID = userID,
                City = city,
                Description=description,
            };
            string sql = @"insert into dbo.[Group] (groupName, groupTime, groupCreater,userID,city,description)
                                  values(@GroupName, @GroupTime,@GroupCreater,@UserID,@City,@Description);";
            return DAO.SaveData(sql, data);
        }
        public static List<GroupModel> LoadGroups()
        {
            string sql = @"select  groupName, groupTime, groupCreater,userID,city,description
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
        public static string isPrivate(string postTitle)
        {
            string sql = @"select groupID from dbo.[Post] where postTitle='" + @postTitle + "'";

            return DAO.GetUserName(sql);
        }
        
        public static int SearchGroups(int groupID)
        {
            GroupModel data = new GroupModel
            {
                GroupId = groupID,
            };
            string sql = @"select groupName, groupTime, groupCreater,userID
                        from dbo.[Group] where groupID ='" + @groupID + "'";
            return DAO.SaveData(sql, data);
        }

    }
}

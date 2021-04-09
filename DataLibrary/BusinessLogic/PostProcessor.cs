using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class PostProcessor
    {
        public static int CreatePosts(string postTitle, string postContent, string postDate, string postAuthor, string userID)
        {
            PostModel data = new PostModel
            {
                PostTitle = postTitle,
                PostContent = postContent,
                PostDate = postDate,
                PostAuthor= postAuthor,
                UserID= userID,
            };
            string sql = @"insert into dbo.[Post] (postTitle, postContent, postDate,postAuthor,userID)
                                  values(@PostTitle, @PostContent,@PostDate,@PostAuthor,@UserID );";
            return DAO.SaveData(sql, data);
        }
        public static List<PostModel> LoadPosts()
        {
            string sql = @"select  postTitle, postContent, postDate,postAuthor,userID,numOfLike
                              from dbo.[Post];";
            return DAO.LoadData<PostModel>(sql);
        }
        public static int LikeAddP(int numOfLike)
        {
            PostModel data = new PostModel
            {
                numOfLike = numOfLike,
            };
            string sql = @"update dbo.[Post] set numOfLike = numOfLike + 1;";
            return DAO.SaveData(sql, data);
        }
        public static string GetPostID(string postTitle)
        {
            string sql = @"select postID from dbo.[Post] where postTitle='" + postTitle + "'";

            return DAO.GetUserName(sql);
        }
        public static bool CheckDupP(string postTitle)
        {
            string sql = @"select count(postTitle) from dbo.[Post] where postTitle='" + postTitle + "'";

            return DAO.GetData(sql);
        }
    }
}

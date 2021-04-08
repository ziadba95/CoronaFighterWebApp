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
            string sql = @"select  postTitle, postContent, postDate,postAuthor,userID
                              from dbo.[Post];";
            return DAO.LoadData<PostModel>(sql);
        }
    }
}

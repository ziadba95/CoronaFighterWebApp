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
        public static int CreatePosts(string postTitle, string postContent, string postDate)
        {
            PostModel data = new PostModel
            {
                PostTitle = postTitle,
                PostContent = postContent,
                PostDate = postDate,
            };
            string sql = @"insert into dbo.[Post] (postTitle, postContent, PostDate)
                                  values(@PostTitle, @PostContent,@PostDate );";
            return DAO.SaveData(sql, data);
        }
        public static List<PostModel> LoadPosts()
        {
            string sql = @"select  postTitle, postContent, PostDate
                              from dbo.[Post];";
            return DAO.LoadData<PostModel>(sql);
        }
    }
}

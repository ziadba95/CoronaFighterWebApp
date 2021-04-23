using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;
namespace DataLibrary.BusinessLogic
{
    public static class CommentProcessor
    {
        public static int CreateComment(string commentText, string userID, string postID, string commentDate, string commentAuthor)
        {
            CommentModel data = new CommentModel
            {
                UserID = userID,
                PostID = postID,
                CommentText = commentText,
                CommentDate = commentDate,
                CommentAuthor = commentAuthor,
            };
            string sql = @"insert into dbo.[Comment] (commentText, userID, postID,commentDate,commentAuthor)
                                  values(@CommentText,@UserID, @PostID,@CommentDate,@CommentAuthor);";
            return DAO.SaveData(sql, data);
        }

        public static List<CommentModel> LoadComments(int postID)
        {
            string sql = @"select  commentID,commentText, userID, postID,commentDate,commentAuthor
                              from dbo.[Comment] where postID ='" + @postID + "'";
            return DAO.LoadData<CommentModel>(sql);
        }
    }
}

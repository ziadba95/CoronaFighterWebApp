﻿using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class LectureProcessor
    {
        public static int CreateLecture(string lectureTitle, string lectureDescription, string lectureLink, DateTime lectureDate, DateTime lectureTime, string lectureAuthor, string userID)
        {
            LectureModel data = new LectureModel
            {
                LectureTitle = lectureTitle,
                LectureDescription = lectureDescription,
                LectureLink= lectureLink,
                LectureDate = lectureDate,
                LectureTime= lectureTime,
                LectureAuthor = lectureAuthor,
                UserID = userID,
            };
            string sql = @"insert into dbo.[Lecture] (lectureTitle, lectureDescription, lectureLink,lectureDate,lectureTime,lectureAuthor,userID)
                                  values(@LectureTitle, @LectureDescription,@LectureLink ,@LectureDate,@LectureTime,@LectureAuthor,@UserID);";
            return DAO.SaveData(sql, data);
        }
        public static List<LectureModel> LoadLectures()
        {
            string sql = @"select  lectureTitle, lectureDescription, lectureLink,lectureDate,lectureTime,numOfLike
                              from dbo.[Lecture];";
            return DAO.LoadData<LectureModel>(sql);
        }
        public static List<LectureModel> LoadLecturesByUser(string UserID)
        {
            string sql = @"select  lectureTitle, lectureDescription, lectureLink,lectureDate,lectureTime,numOfLike
                              from dbo.[Lecture] where userID=" + @UserID;
            return DAO.LoadData<LectureModel>(sql);
        }
        public static int LikeAddL(int numOfLike,int? lectureId)
        {
            LectureModel data = new LectureModel
            {
                numOfLike = numOfLike,
            };
            string sql = @"update dbo.[Lecture] set numOfLike = numOfLike + 1 where lectureId='" + @lectureId + "'";
            return DAO.SaveData(sql, data);
        }
        public static string GetLectureID(string lectureTitle)
        {
            string sql = @"select userID from dbo.[Lecture] where lectureTitle='" + @lectureTitle + "'";

            return DAO.GetUserName(sql);
        }
        public static bool CheckDup(string lectureTitle)
        {
            string sql = @"select count(lectureTitle) from dbo.[Lecture] where lectureTitle='" + @lectureTitle + "'";

            return DAO.GetData(sql);
        }
        public static int DeleteLectures(string lectureTitle)
        {
            LectureModel data = new LectureModel
            {
                LectureTitle = lectureTitle,
            };
            string sql = @"delete from dbo.[Lecture] where lectureTitle ='" + @lectureTitle + "'";

            return DAO.SaveData(sql, data);
        }
        public static int EditLectures(string lectureTitle, DateTime lectureDate, DateTime lectureTime)
        {
            LectureModel data = new LectureModel
            {
                LectureTitle = lectureTitle,
                LectureDate = lectureDate,
                LectureTime = lectureTime,
            };
            string sql = @"update dbo.[Lecture] set lectureDate='" + @lectureDate + "',lectureTime='" +
                @lectureTime + "' where lectureTitle='" + @lectureTitle + "'";
                                  
            return DAO.SaveData(sql, data);
        }
    }
}

using DataLibrary.DataAccess;
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
        public static int CreateLecture(string lectureTitle, string lectureDescription, string lectureLink, DateTime lectureDate, DateTime lectureTime)
        {
            LectureModel data = new LectureModel
            {
                LectureTitle = lectureTitle,
                LectureDescription = lectureDescription,
                LectureLink= lectureLink,
                LectureDate = lectureDate,
                LectureTime= lectureTime,
            };
            string sql = @"insert into dbo.[Lecture] (lectureTitle, lectureDescription, lectureLink,lectureDate,lectureTime)
                                  values(@LectureTitle, @LectureDescription,@LectureLink ,@LectureDate,@LectureTime);";
            return DAO.SaveData(sql, data);
        }
        public static List<LectureModel> LoadLectures()
        {
            string sql = @"select  lectureTitle, lectureDescription, lectureLink,lectureDate,lectureTime,numOfLike
                              from dbo.[Lecture];";
            return DAO.LoadData<LectureModel>(sql);
        }
        public static int LikeAdd(int numOfLike)
        {
            LectureModel data = new LectureModel
            {
                numOfLike = numOfLike,
            };
            string sql = @"update dbo.[Lecture] set numOfLike = numOfLike + 1;";
            return DAO.SaveData(sql, data);
        }
    }
}

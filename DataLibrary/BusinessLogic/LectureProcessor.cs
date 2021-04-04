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
        public static int CreateLecture(string lectureTitle, string lectureDescription, string lectureLink, DateTime lectureDate)
        {
            LectureModel data = new LectureModel
            {
                LectureTitle = lectureTitle,
                LectureDescription = lectureDescription,
                LectureLink= lectureLink,
                LectureDate = lectureDate,
            };
            string sql = @"insert into dbo.[Lecture] (lectureTitle, lectureDescription, lectureLink,lectureDate)
                                  values(@LectureTitle, @LectureDescription,@LectureLink ,@LectureDate);";
            return DAO.SaveData(sql, data);
        }
        public static List<LectureModel> LoadLectures()
        {
            string sql = @"select  lectureTitle, lectureDescription, lectureLink,lectureDate
                              from dbo.[Lecture];";
            return DAO.LoadData<LectureModel>(sql);
        }
    }
}

using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
	public static class VideoProcessor
	{
        public static int AddVideo(string vtitle, string vURL, string imgLink)
        {
            VideoModel data = new VideoModel
            {
                VideoTitle = vtitle,
                VideoURL = vURL,
                ImageLink = imgLink,
             
            };
            string sql = @"insert into dbo.[Video] (videoTitle, videoUrl, imageLink)
                                  values(@VideoTitle, @VideoURL, @ImageLink);";
            return DAO.SaveData(sql, data);
        }
		public static List<VideoModel> LoadVideos()
        {
            string sql = @"select  videoTitle, videoUrl, imageLink
                              from dbo.[Video];";
            return DAO.LoadData<VideoModel>(sql);
        }
    }
}

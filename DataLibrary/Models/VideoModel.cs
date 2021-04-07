using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
	public class VideoModel
	{
		public int? VideoId { get; set; }
		public string VideoTitle { get; set; }
		public string VideoURL { get; set; }
		public string ImageLink { get; set; }
	}
}

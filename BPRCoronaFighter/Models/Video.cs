using DataLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace BPRCoronaFighter.Models
{
	public class Video
	{
		[HiddenInput(DisplayValue = false)]
		public int? VideoId { get; set; }

		[Required]
		[DisplayName("Video Title")]
		public string VideoTitle { get; set; }

		[Required]
		[DisplayName("Video URL")]
		public string VideoURL { get; set; }

		[Required]
		[DisplayName("Image Link")]
		public string ImageLink { get; set; }

	}

}
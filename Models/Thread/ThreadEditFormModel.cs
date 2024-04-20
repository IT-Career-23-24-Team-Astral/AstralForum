using AstralForum.ServiceModels;
using Microsoft.Build.Framework;

namespace AstralForum.Models.Thread
{
	public class ThreadEditFormModel
	{
		public int ThreadDtoId { get; set; }

		[Required]
		public string UpdatedText { get; set; }

		[Required]
		public string UpdatedTitle { get; set; }
	}
}

using AstralForum.ServiceModels;
using Microsoft.Build.Framework;

namespace AstralForum.Models.Thread
{
	public class ThreadEditFormModel
	{
		public int ThreadDtoId { get; set; }
		public string UpdatedText { get; set; }
	}
}

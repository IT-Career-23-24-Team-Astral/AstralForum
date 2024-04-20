using AstralForum.Data.Entities.Thread;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
	public static class ThreadAttachmentMapping
	{
		public static ThreadAttachment ToEntity(this ThreadAttachmentDto threadAttachmentDto)
		{
			ThreadAttachment threadAttachment = new ThreadAttachment();

			threadAttachment.Id = threadAttachmentDto.Id;
			threadAttachment.ThreadId = threadAttachmentDto.ThreadId;
			threadAttachment.AttachmentUrl = threadAttachmentDto.AttachmentUrl;
			threadAttachment.FileName = threadAttachmentDto.FileName;

			return threadAttachment;
		}
		public static ThreadAttachmentDto ToDto(this ThreadAttachment threadAttachment)
		{
			ThreadAttachmentDto threadAttachmentDto = new ThreadAttachmentDto();

			threadAttachmentDto.Id = threadAttachment.Id;
			threadAttachmentDto.ThreadId = threadAttachment.ThreadId;
			threadAttachmentDto.AttachmentUrl = threadAttachment.AttachmentUrl;
			threadAttachmentDto.FileName = threadAttachment.FileName;

			return threadAttachmentDto;
		}
	}
}

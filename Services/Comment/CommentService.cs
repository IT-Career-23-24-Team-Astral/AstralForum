
using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Models.Comment;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Services.Comment;

namespace AstralForum.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
			_commentRepository = commentRepository;
        }
        public async Task<CommentDto> AddComment(CommentDto commentDto, User createdBy)
        {
            Data.Entities.Comment.Comment comment = commentDto.ToEntity();

            comment.CreatedBy = createdBy;

            return (await _commentRepository.Create(comment)).ToDto();
        }
        public async Task<CommentDto> EditComment(CommentDto commentDto)
        {
            Data.Entities.Comment.Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Edit(comment)).ToDto();
        }

        public async Task<List<CommentDto>> GetAllCommentsByThreadId(int id)
        {
            List<Data.Entities.Comment.Comment> comments = await _commentRepository.GetCommentsByThreadId(id);
            List<CommentDto> commentDtos = comments.Select(comment => comment.ToDto()).ToList();

            return commentDtos;
        }

        public async Task<List<CommentDto>> GetAllRepliesByCommentId(int id)
        {
            List<Data.Entities.Comment.Comment> comments = await _commentRepository.GetRepliesByCommentId(id);
            List<CommentDto> commentDtos = comments.Select(comment => comment.ToDto(includeReplies: false)).ToList();

            return commentDtos;
        }
        public async Task<CommentDto> DeleteComment(CommentDto commentDto)
        {
            Data.Entities.Comment.Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Delete(comment)).ToDto();
        }
        public CommentTableViewModel GetCommentTableViewModel(CommentDto commentDto)
        {
            CommentTableViewModel model = new CommentTableViewModel()
			{
				Id = commentDto.Id,
				Text = commentDto.Text,
				Author = commentDto.CreatedBy,
				DateOfCreation = commentDto.CreatedOn,
			
			};
            return model;
        }

    }
}
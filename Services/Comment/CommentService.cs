
using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Models.Comment;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Services.Comment;
using Microsoft.EntityFrameworkCore;

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

		public CommentDto GetCommentByCommentIdWithReactions(int id)
		{
            return _commentRepository.GetAll()
                .Include(c => c.CreatedBy)
                .Include(c => c.Reactions)
                    .ThenInclude(r => r.ReactionType)
                .Single(c => c.Id == id).ToDto(true, false, false);
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

        public async Task<List<CommentDto>> GetAllHiddenComments()
        {
            var hiddenComments = await _commentRepository.GetAllHiddenComments();

            var commentsDtos = hiddenComments.Select(comment => comment.ToDto(false, false, false)).ToList();

            return commentsDtos;
        }
        public async Task<List<CommentDto>> GetAllDeletedComments()
        {
            var deletedComments = await _commentRepository.GetAllDeletedComments();

            var commetsDtos = deletedComments.Select(comment => comment.ToDto(false, false, false)).ToList();

            return commetsDtos;
        }
        public CommentDto HideComment(int id)
        {
            CommentDto commentDto = _commentRepository.HideComment(id).ToDto(false, false, false, false);
            return commentDto;
        }
        public CommentDto UnhideComment(int id)
        {
            CommentDto commentDto = _commentRepository.UnhideComment(id).ToDto(false, false, false, false);
            return commentDto;
        }
        public CommentDto DeleteComment(int id)
        {
            CommentDto commentDto = _commentRepository.DeleteComment(id).ToDto(false, false, false, false);
            return commentDto;
        }
        public CommentDto GetDeletedCommentBack(int id)
        {
            CommentDto commentDto = _commentRepository.GetDeletedCommentBack(id).ToDto(false, false, false, false);
            return commentDto;
        }
        public void DeleteAllCommentsByUserId(int userId)
        {
            _commentRepository.DeleteAllCommentsByUserId(userId);
        }

    }
}
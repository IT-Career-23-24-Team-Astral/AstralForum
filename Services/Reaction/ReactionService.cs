using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Reaction
{
    public class ReactionService : IReactionService
    {
        private readonly CommentReactionRepository _commentReactionRepository;

        public ReactionService(CommentReactionRepository commentReactionRepository)
        {
            _commentReactionRepository = commentReactionRepository;
        }
        public async Task<CommentReactionDto> AddCommentReaction(CommentReactionDto commentReactionDto)
        {
            Data.Entities.Reaction.CommentReaction commentReaction = commentReactionDto.ToEntity();

            return (await _commentReactionRepository.Create(commentReaction)).ToDto();
        }
        /*public async Task<ReactionDto> DeleteReaction(ReactionDto reactionDto)
        {
            Data.Entities.Reaction.Reaction reaction = reactionDto.ToEntity();

            return (await _reactionRepository.Delete(reaction)).ToDto();
        }
        public async Task<List<ReactionDto>> GetAllReactionsByThreadId(int id)
        {
            List<Data.Entities.Reaction.Reaction> reactions = await _reactionRepository.GetReactionsByThreadId(id);
            List<ReactionDto> reactionDtos = reactions.Select(c => c.ToDto()).ToList();

            return reactionDtos;
        }
        public async Task<List<ReactionDto>> GetAllReactionsByCommentId(int id)
        {
            List<Data.Entities.Reaction.Reaction> reactions = await _reactionRepository.GetReactionsByCommentId(id);
            List<ReactionDto> reactionDtos = reactions.Select(c => c.ToDto()).ToList();

            return reactionDtos;
        }*/
    }
}

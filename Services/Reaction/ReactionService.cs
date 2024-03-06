using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Reaction
{
    public class ReactionService
    {
        private readonly ReactionRepository _reactionRepository;

        public ReactionService(ReactionRepository reactionRepository)
        {
            _reactionRepository = reactionRepository;
        }
        public async Task<ReactionDto> AddReaction(ReactionDto reactionDto)
        {
            Data.Entities.Reaction.Reaction reaction = reactionDto.ToEntity();

            return (await _reactionRepository.Create(reaction)).ToDto();
        }
        public async Task<ReactionDto> DeleteReaction(ReactionDto reactionDto)
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
        }
    }
}


using AstralForum.Data.Entities.Tag;
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.Repositories.Interfaces;
using AstralForum.ServiceModels;
using Azure;

namespace AstralForum.Services
{
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepository;

        public TagService(TagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<TagDto> AddTag(TagDto tagDto)
        {
            Tag tag = tagDto.ToEntity();

            return (await _tagRepository.Create(tag)).ToDto();
        }

        public async Task<List<TagDto>> GetAllTagsByThreadId(int id)
        {
            List<Tag> tags = await _tagRepository.GetTagsByThreadId(id);
            List<TagDto> tagDtos = tags.Select(tag => tag.ToDto()).ToList();

            return tagDtos;
        }

        public async Task<List<TagDto>> GetAllTagsByCommentId(int id)
        {
            List<Tag> tags = await _tagRepository.GetTagsByCommentId(id);
            List<TagDto> tagDtos = tags.Select(tag => tag.ToDto()).ToList();

            return tagDtos;
        }
        public async Task<List<TagDto>> GetAllTagsByTagId(int id)
        {
            List<Tag> tags = await _tagRepository.GetTagsByTagId(id);
            List<TagDto> tagDtos = tags.Select(tag => tag.ToDto()).ToList();

            return tagDtos;
        }

    }
}

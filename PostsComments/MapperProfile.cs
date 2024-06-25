using PostsComments.Data.Entities;
using PostsComments.DTO;
using System.Data;
using AutoMapper;
using PostsComments.DTO;
using PostsComments.Data.Entities;

namespace Lesson27Task
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostDTO, Post>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<CommentDTO, Comment>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Comment, CommentDTO>();
        }
    }
}

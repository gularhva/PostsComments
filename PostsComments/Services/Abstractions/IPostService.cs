using PostsComments.Data.Entities;
using PostsComments.DTO;

namespace PostsComments.Services.Abstractions
{
    public interface IPostService
    {
        public ResponseModel<IEnumerable<Post>> Get();
        public ResponseModel<Post> Post(PostDTO model);
        public ResponseModel<Post> Delete(int id);
        public ResponseModel<Post> Update(int id, PostDTO model);
        public Post GetById(int id);
    }
}

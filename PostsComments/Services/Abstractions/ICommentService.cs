using PostsComments.Data.Entities;
using PostsComments.DTO;

namespace PostsComments.Services.Abstractions
{
    public interface ICommentService
    {
        public ResponseModel<IEnumerable<Comment>> Get();
        public ResponseModel<Comment> Post(CommentDTO model);
        public ResponseModel<Comment> Delete(int id);
        public ResponseModel<Comment> Update(int id, CommentDTO model);
        public Comment GetById(int id);
    }
}

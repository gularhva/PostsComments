using PostsComments.Data;
using PostsComments.Data.Entities;
using PostsComments.Services.Abstractions;

namespace PostsComments.Services.Implementations
{
    public class CommentRepository:GenericRepository<Comment>,ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}

using PostsComments.Data.Entities;
using PostsComments.Data;
using PostsComments.Services.Abstractions;

namespace PostsComments.Services.Implementations
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

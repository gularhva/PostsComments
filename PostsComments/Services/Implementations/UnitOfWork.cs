using PostsComments.Data;
using PostsComments.Services.Abstractions;

namespace PostsComments.Services.Implementations
{
    public class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PostR = new PostRepository(_context);
            CommentR = new CommentRepository(_context);

        }
        public IPostRepository PostR { get; private set; }
        public ICommentRepository CommentR { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

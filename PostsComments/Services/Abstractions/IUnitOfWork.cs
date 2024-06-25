namespace PostsComments.Services.Abstractions
{
    public interface IUnitOfWork:IDisposable
    {
        IPostRepository PostR { get; }
        ICommentRepository CommentR { get; }
        void Save();
    }
}

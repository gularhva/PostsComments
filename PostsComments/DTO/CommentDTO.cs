namespace PostsComments.DTO
{
    public class CommentDTO
    {
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
    }
}

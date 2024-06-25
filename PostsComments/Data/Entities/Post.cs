using System.ComponentModel.DataAnnotations;

namespace PostsComments.Data.Entities
{
    public class Post
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Text { get; set; }
        public int AuthorId { get; set; }
        [MaxLength(50)]
        public string PublishedData { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

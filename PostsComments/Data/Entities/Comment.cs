using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PostsComments.Data.Entities
{
    public class Comment
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
        [JsonIgnore]
        public virtual Post Post { get; set; }
    }
}

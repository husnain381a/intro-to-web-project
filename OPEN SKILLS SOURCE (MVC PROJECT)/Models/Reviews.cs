using System.ComponentModel.DataAnnotations;

namespace OPEN_SKILLS_SOURCE__MVC_PROJECT_.Models
{
        public class Reviews
        {
            [Key]
            public int Id { get; set; }
            public string Username { get; set; }
            public string Content { get; set; }
            public DateTime CreatedAt { get; set; }
        }
}

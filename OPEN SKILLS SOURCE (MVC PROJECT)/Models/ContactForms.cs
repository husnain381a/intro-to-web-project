using System.ComponentModel.DataAnnotations;

namespace OPEN_SKILLS_SOURCE__MVC_PROJECT_.Models
{
    public class ContactForms
    {
        [Key]
        public int ContactNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace JwtBearerExample.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(5, ErrorMessage = "It must contains between 5 and 50 characters")]
        [MaxLength(20, ErrorMessage = "It must contains between 5 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(5, ErrorMessage = "It must contains between 5 and 10 characters")]
        [MaxLength(10, ErrorMessage = "It must contains between 5 and 10 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(6, ErrorMessage = "It must contains 6 or more characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public Role Role { get; set; }
    }
}
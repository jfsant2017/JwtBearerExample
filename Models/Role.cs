using System.ComponentModel.DataAnnotations;

namespace JwtBearerExample.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        
        [Required(ErrorMessage="This field is required")]
        [MinLength(4, ErrorMessage="It must contains 4 or more characters")]
        public string Name { get; set; }
    }
}
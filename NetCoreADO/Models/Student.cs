using System.ComponentModel.DataAnnotations;

namespace NetCoreADO.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required] 
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}

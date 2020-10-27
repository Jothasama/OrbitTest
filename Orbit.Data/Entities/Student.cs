using System.ComponentModel.DataAnnotations;

namespace Orbit.Data.Entities
{
    public class Student : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(50)]
        public string Career { get; set; }
    }
}
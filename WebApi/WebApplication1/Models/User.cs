using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public UserType Type { get; set; }
        public string Subject {get;set;}
        [Range(0, 12, ErrorMessage = "Standard can be in between of 0 to 13")]
        public int Std { get; set; }
    }
    public enum UserType
    {
        Student = 1,
        Teacher = 2
    }
}

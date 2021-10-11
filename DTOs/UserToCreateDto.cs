using System;
using System.ComponentModel.DataAnnotations;

namespace PhyndDemo_v2.DTOs{

    public class UserToCreateDto{

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int UserHospitalId { get; set; }
        
    }
}
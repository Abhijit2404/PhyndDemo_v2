using System;
using System.ComponentModel.DataAnnotations;

namespace PhyndDemo_v2.DTOs{

    public class ProviderToCreateDto{

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int HospitalId { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace PhyndDemo_v2.DTOs{

    public class ProgramToCreateDto{

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
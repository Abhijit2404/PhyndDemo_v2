using System;

namespace PhyndDemo_v2.DTOs{

    public class ProgramToCreateDto{

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
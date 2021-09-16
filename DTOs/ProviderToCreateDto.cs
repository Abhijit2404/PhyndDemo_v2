using System;

namespace PhyndDemo_v2.DTOs{

    public class ProviderToCreateDto{

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        
    }
}
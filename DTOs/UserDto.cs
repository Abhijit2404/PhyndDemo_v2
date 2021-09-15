using System;
namespace PhyndDemo_v2.DTOs{

    public class UserDto{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isDeleted { get; set; }
        public int UserHospitalId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
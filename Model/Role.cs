using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Model
{
    [Table("role")]
    public partial class Role
    {
        public Role()
        {
            Userroles = new HashSet<Userrole>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("isDeleted")]
        public bool? IsDeleted { get; set; }

        [InverseProperty(nameof(Userrole.Role))]
        public virtual ICollection<Userrole> Userroles { get; set; }
    }
}

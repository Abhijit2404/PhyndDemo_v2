using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Model
{
    [Table("userrole")]
    [Index(nameof(RoleId), Name = "roleId")]
    [Index(nameof(UserId), Name = "userId")]
    public partial class Userrole
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("roleId", TypeName = "int(11)")]
        public int RoleId { get; set; }
        [Column("userId", TypeName = "int(11)")]
        public int UserId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Userroles")]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Userroles")]
        public virtual User User { get; set; }
    }
}

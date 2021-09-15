using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Model
{
    [Table("program")]
    public partial class Program
    {
        public Program()
        {
            Providerprograms = new HashSet<Providerprogram>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("userId", TypeName = "int(11)")]
        public int? UserId { get; set; }
        [Column("createdOn")]
        public DateTime CreatedOn { get; set; }
        [Column("modifiedOn")]
        public DateTime ModifiedOn { get; set; }
        [Column("isDeleted")]
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(Providerprogram.Program))]
        public virtual ICollection<Providerprogram> Providerprograms { get; set; }
    }
}

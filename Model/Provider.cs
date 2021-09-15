using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Model
{
    [Table("provider")]
    [Index(nameof(HospitalId), Name = "provider_ibfk_1")]
    public partial class Provider
    {
        public Provider()
        {
            Providerprograms = new HashSet<Providerprogram>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [Column("middleName")]
        [StringLength(30)]
        public string MiddleName { get; set; }
        [Required]
        [Column("lastName")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column("userId", TypeName = "int(11)")]
        public int? UserId { get; set; }
        [Column("createdOn")]
        public DateTime CreatedOn { get; set; }
        [Column("modifiedOn")]
        public DateTime ModifiedOn { get; set; }
        [Column("isDeleted")]
        public bool IsDeleted { get; set; }
        [Column("hospitalId", TypeName = "int(11)")]
        public int? HospitalId { get; set; }

        [ForeignKey(nameof(HospitalId))]
        [InverseProperty("Providers")]
        public virtual Hospital Hospital { get; set; }
        [InverseProperty(nameof(Providerprogram.Provider))]
        public virtual ICollection<Providerprogram> Providerprograms { get; set; }
    }
}

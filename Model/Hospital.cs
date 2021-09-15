using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Model
{
    [Table("hospital")]
    public partial class Hospital
    {
        public Hospital()
        {
            Providers = new HashSet<Provider>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("addressLine1")]
        [StringLength(50)]
        public string AddressLine1 { get; set; }
        [Required]
        [Column("addressLine2")]
        [StringLength(50)]
        public string AddressLine2 { get; set; }
        [Column("addressLine3")]
        [StringLength(50)]
        public string AddressLine3 { get; set; }
        [Required]
        [Column("zipCode")]
        [StringLength(10)]
        public string ZipCode { get; set; }
        [Required]
        [Column("city")]
        [StringLength(20)]
        public string City { get; set; }
        [Required]
        [Column("state")]
        [StringLength(20)]
        public string State { get; set; }
        [Required]
        [Column("country")]
        [StringLength(20)]
        public string Country { get; set; }

        [InverseProperty(nameof(Provider.Hospital))]
        public virtual ICollection<Provider> Providers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Model
{
    [Table("providerprogram")]
    [Index(nameof(ProgramId), Name = "providerprogram_ibfk_1")]
    [Index(nameof(ProviderId), Name = "providerprogram_ibfk_2")]
    public partial class Providerprogram
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("programId", TypeName = "int(11)")]
        public int? ProgramId { get; set; }
        [Column("providerId", TypeName = "int(11)")]
        public int? ProviderId { get; set; }
        [Column("isDeleted")]
        public bool? IsDeleted { get; set; }
        [Column("createdOn")]
        public DateTime? CreatedOn { get; set; }
        [Column("modifiedOn")]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey(nameof(ProgramId))]
        [InverseProperty("Providerprograms")]
        public virtual Program Program { get; set; }
        [ForeignKey(nameof(ProviderId))]
        [InverseProperty("Providerprograms")]
        public virtual Provider Provider { get; set; }
    }
}

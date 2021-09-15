using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Model
{
    [Table("history")]
    public partial class History
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("action")]
        [StringLength(50)]
        public string Action { get; set; }
        [Column("onDatabase")]
        [StringLength(100)]
        public string OnDatabase { get; set; }
        [Column("actionTime")]
        public DateTime? ActionTime { get; set; }
        [Column("query")]
        [StringLength(255)]
        public string Query { get; set; }
        [Column("createdBy")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
    }
}

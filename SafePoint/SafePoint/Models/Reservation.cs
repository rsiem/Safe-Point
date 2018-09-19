namespace SafePoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [Key]
        public int ResvId { get; set; }

        public int HospId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public DateTime ResvTime { get; set; }
    }
}

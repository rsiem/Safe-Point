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

        [Required]
        public int HospId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Hospital Name")]
        public string HospName { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Reservation Time")]
        public DateTime ResvTime { get; set; }

        [Required]
        public string Title { get; set; }
    }
}

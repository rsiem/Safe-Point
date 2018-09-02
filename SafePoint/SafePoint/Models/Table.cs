namespace SafePoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        [Key]
        public int HospId { get; set; }

        [Required]
        public string HospName { get; set; }

        [Required]
        [StringLength(25)]
        public string HospType { get; set; }

        public string LGA { get; set; }

        public string ServiceName { get; set; }

        public int? PhoneNum { get; set; }

        [Required]
        [StringLength(10)]
        public string StreetNumber { get; set; }

        [Required]
        public string RoadName { get; set; }

        [Required]
        [StringLength(30)]
        public string RoadType { get; set; }

        [StringLength(5)]
        public string RoadSuffix { get; set; }

        [Required]
        [StringLength(5)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(15)]
        public string State { get; set; }
    }
}

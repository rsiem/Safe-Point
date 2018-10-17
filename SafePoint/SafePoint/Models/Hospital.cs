namespace SafePoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hospital")]
    public partial class Hospital
    {
        [Key]
        public int HospId { get; set; }

        [Required]
        [Display(Name = "Hospital Name")]
        public string HospName { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Hospital Type")]
        public string HospType { get; set; }

        public string LGA { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Display(Name = "Phone Number")]
        public int? PhoneNum { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Street Number")]
        public string StreetNum { get; set; }

        [Required]
        [Display(Name = "Road Name")]
        public string RoadName { get; set; }

        [StringLength(5)]
        [Display(Name = "Road Suffix")]
        public string RoadSuffix { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Road Type")]
        public string RoadType { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "State")]
        public string State { get; set; }

        [DisplayFormat(DataFormatString ="{0:###.########}")]
        [Column(TypeName = "numeric")]
        public decimal Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:###.#########}")]
        [Column(TypeName = "numeric")]
        public decimal Longitude { get; set; }
    }
}

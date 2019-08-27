namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BasicInfo")]
    public partial class BasicInfo
    {
        public int BasicInfoId { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public string FbLogin { get; set; }

        public string TwitterLogin { get; set; }

        public string InstaLogin { get; set; }

        public string LinkedLogin { get; set; }

        public DateTime? OpenDate { get; set; }

        public DateTime? CloseDate { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string AdminPassword { get; set; }
    }
}

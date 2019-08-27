namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResetImageTB")]
    public partial class ResetImageTB
    {
        [Key]
        public int ResetImageId { get; set; }

        public string ResetPhoto { get; set; }
    }
}

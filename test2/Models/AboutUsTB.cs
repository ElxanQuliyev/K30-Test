namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AboutUsTB")]
    public partial class AboutUsTB
    {
        [Key]
        public int AboutUsId { get; set; }

        [Required]
        public string AboutUsPhoto { get; set; }
    }
}

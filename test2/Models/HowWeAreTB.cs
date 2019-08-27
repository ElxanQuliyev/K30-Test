namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HowWeAreTB")]
    public partial class HowWeAreTB
    {
        [Key]
        public int HowWeAreID { get; set; }

        public string Description { get; set; }

        [Required]
        public string HPhoto { get; set; }

        public int LanguageId { get; set; }

        public virtual LanguageTB LanguageTB { get; set; }
    }
}

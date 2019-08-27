namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AreasOfActivity")]
    public partial class AreasOfActivity
    {
        public int AreasOfActivityId { get; set; }

        [Required]
        [StringLength(500)]
        public string Headline { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string AreasIcon { get; set; }

        public int? LanguageId { get; set; }

        public virtual LanguageTB LanguageTB { get; set; }
    }
}

namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SliderTopTB")]
    public partial class SliderTopTB
    {
        [Key]
        public int SliderTopId { get; set; }

        [StringLength(250)]
        public string SliderContent1 { get; set; }

        [StringLength(250)]
        public string SliderContent2 { get; set; }

        [Required]
        public string SliderTopImage { get; set; }

        public int LanguageId { get; set; }

        public virtual LanguageTB LanguageTB { get; set; }
    }
}

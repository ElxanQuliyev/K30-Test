namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            LabelTBs = new HashSet<LabelTB>();
        }

        public int ArticleId { get; set; }

        [Required]
        public string Headline { get; set; }

        public string ArticleContent { get; set; }

        public string IframeLink { get; set; }

        public long? Reads { get; set; }

        public DateTime? CreateDate { get; set; }

        public string ArticlePhoto { get; set; }

        public int LanguageId { get; set; }

        public virtual LanguageTB LanguageTB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LabelTB> LabelTBs { get; set; }
    }
}

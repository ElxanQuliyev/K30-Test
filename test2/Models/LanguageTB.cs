namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LanguageTB")]
    public partial class LanguageTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LanguageTB()
        {
            AreasOfActivities = new HashSet<AreasOfActivity>();
            Articles = new HashSet<Article>();
            AttorneyTBs = new HashSet<AttorneyTB>();
            HowWeAreTBs = new HashSet<HowWeAreTB>();
            SliderTopTBs = new HashSet<SliderTopTB>();
        }

        [Key]
        public int LanguageId { get; set; }

        [StringLength(50)]
        public string CultureCode { get; set; }

        [StringLength(100)]
        public string CultureName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AreasOfActivity> AreasOfActivities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttorneyTB> AttorneyTBs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HowWeAreTB> HowWeAreTBs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SliderTopTB> SliderTopTBs { get; set; }
    }
}

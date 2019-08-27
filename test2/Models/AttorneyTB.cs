namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttorneyTB")]
    public partial class AttorneyTB
    {
        [Key]
        public int AttorneyId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public string Description { get; set; }

        [StringLength(30)]
        public string Phone1 { get; set; }

        [StringLength(30)]
        public string Phone2 { get; set; }

        public string AttorneyPhoto { get; set; }

        [StringLength(100)]
        public string WorkSector { get; set; }

        public int LanguageId { get; set; }

        public virtual LanguageTB LanguageTB { get; set; }
    }
}

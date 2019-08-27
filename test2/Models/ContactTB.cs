namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactTB")]
    public partial class ContactTB
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string ContactPhoto { get; set; }
    }
}

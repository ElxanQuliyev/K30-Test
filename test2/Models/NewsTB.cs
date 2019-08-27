namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsTB")]
    public partial class NewsTB
    {
        [Key]
        public int NewsId { get; set; }

        public string NewsPhoto { get; set; }
    }
}

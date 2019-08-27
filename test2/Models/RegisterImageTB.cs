namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegisterImageTB")]
    public partial class RegisterImageTB
    {
        [Key]
        public int RegisterImageId { get; set; }

        public string RegisterPhoto { get; set; }
    }
}

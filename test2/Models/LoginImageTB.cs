namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginImageTB")]
    public partial class LoginImageTB
    {
        [Key]
        public int LoginImageId { get; set; }

        public string LoginPhoto { get; set; }
    }
}

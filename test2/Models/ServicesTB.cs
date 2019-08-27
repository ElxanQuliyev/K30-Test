namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServicesTB")]
    public partial class ServicesTB
    {
        [Key]
        public int ServicesId { get; set; }

        public string ServicesPhoto { get; set; }
    }
}

namespace TestCRUDApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Status
    {
        [Key]
        [Column(Order = 0)]
        public Guid Status_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Status_Name { get; set; }
    }
}

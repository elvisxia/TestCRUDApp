namespace TestCRUDApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_User
    {
        [Key]
        [Column(Order = 0)]
        public Guid User_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Display_Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Account_Name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}

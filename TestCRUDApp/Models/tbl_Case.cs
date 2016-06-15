namespace TestCRUDApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Case
    {
        [Key]
        [Column(Order = 0)]
        public Guid Case_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 2)]
        public string URL { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime Created_On { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Modified_On { get; set; }

        [Key]
        [Column(Order = 4)]
        public Guid Owner { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UT { get; set; }

        public TimeSpan? IRT { get; set; }

        public Guid? Status { get; set; }
    }
}

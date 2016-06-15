namespace TestCRUDApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CaseManagement : DbContext
    {
        public CaseManagement()
            : base("name=CaseManagement")
        {
        }

        public virtual DbSet<tbl_Case> tbl_Case { get; set; }
        public virtual DbSet<tbl_Status> tbl_Status { get; set; }
        public virtual DbSet<tbl_Tag> tbl_Tag { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_User>()
                .Property(e => e.Account_Name)
                .IsFixedLength();
        }
    }
}

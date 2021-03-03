using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FleetManagementService.Models
{
    public class FMSDataContext : DbContext
    {
        public DbSet<Container> Containers { get; set; }

        public DbSet<Vessel> Vessels { get; set; }

        public DbSet<Fleet> Fleets { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Container>()
        //    //    .HasOptional<Vessel>(c => c.Vessel)
        //    //    .WithMany(v => v.Containers)
        //    //    .HasForeignKey(c => c.VesselId);
        //    ////.WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Vessel>()
        //        .HasMany(v => v.Containers)
        //        .WithOptional(c => c.Vessel)
        //        .HasForeignKey(c => c.VesselId)
        //        .WillCascadeOnDelete(false);
        //}
    }

}
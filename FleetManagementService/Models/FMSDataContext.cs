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
    }

}
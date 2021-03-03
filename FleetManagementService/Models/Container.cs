using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagementService.Models
{
    [Table(name: "Containers")]
    public class Container
    {
        public int ContainerId { get; set; }

        [Required()]
        [StringLength(30)]
        [Index("Ix_Name", Order = 1, IsUnique = true)]
        public string Name { get; set; }
        
        public int? VesselId { get; set; }

        public virtual Vessel Vessel { get; set; }

        [NotMapped]
        public bool NoVessel { get; set; }

    }
}


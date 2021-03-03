using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagementService.Models
{
    public class Vessel
    {
        public int VesselId { get; set; }

        [Required()]
        [StringLength(30)]
        [Index("Ix_Name", Order = 1, IsUnique = true)]
        public string Name { get; set; }

        [Required()]
        public int Capacity { get; set; }

        public virtual ICollection<Container> Containers { get; set; }

        public int? FleetId { get; set; }
        public virtual Fleet Fleet { get; set; }

        [NotMapped]
        public bool NoFleet { get; set; }
    }
}
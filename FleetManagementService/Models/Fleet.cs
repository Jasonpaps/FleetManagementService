using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagementService.Models
{
    public class Fleet
    {
        public int FleetId { get; set; }

        [Required()]
        [StringLength(30)]
        [Index("Ix_Name", Order = 1, IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Vessel> Vessels { get; set; }
    }
}
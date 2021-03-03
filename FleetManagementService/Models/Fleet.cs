using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FleetManagementService.Models
{
    public class Fleet
    {
        public int FleetId { get; set; }

        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public virtual ICollection<Vessel> Vessels { get; set; }
    }
}
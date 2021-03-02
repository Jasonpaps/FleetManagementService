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
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public Vessel Vessel { get; set; }
    }
}


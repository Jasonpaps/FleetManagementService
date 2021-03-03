﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FleetManagementService.Models
{
    public class Vessel
    {
        public int VesselId { get; set; }

        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required()]
        public int Capacity { get; set; }

        public virtual ICollection<Container> Containers { get; set; }

        public virtual Fleet Fleet { get; set; }
    }
}
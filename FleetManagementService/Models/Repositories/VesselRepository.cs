using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FleetManagementService.Models.Repositories
{
    public class VesselRepository : Repository<Vessel>
    {
        public List<Vessel> GetByName(string name)
        {
            return DbSet.Where(a => a.Name.Contains(name)).ToList();
        }
    }
}
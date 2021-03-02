using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FleetManagementService.Models.Repositories
{
    public class ContainerRepository :Repository<Container>
    {
        public List<Container> GetByName(string name)
        {
            return DbSet.Where(a => a.Name.Contains(name)).ToList();
        }
    }
}
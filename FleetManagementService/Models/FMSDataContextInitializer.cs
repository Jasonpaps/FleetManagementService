using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FleetManagementService.Models
{
    public class FMSDataContextInitializer : DropCreateDatabaseAlways<FMSDataContext>
    {
        protected override void Seed(FMSDataContext context)
        {
            Fleet fleet1 = new Fleet() { Name = "Fleet1" };
            Fleet fleet2 = new Fleet() { Name = "Fleet2" };
            context.Fleets.Add(fleet1);
            context.Fleets.Add(fleet2);

            Vessel vessel1 = new Vessel() { Name = "Vessel1", Capacity = 1, Fleet = fleet1};
            Vessel vessel2 = new Vessel() { Name = "Vessel2", Capacity = 2, Fleet = fleet2};
            Vessel vessel3 = new Vessel() { Name = "Vessel3", Capacity = 3, Fleet = fleet1 };
            context.Vessels.Add(vessel1);
            context.Vessels.Add(vessel2);
            context.Vessels.Add(vessel3);

            Container container1 = new Container() { Name = "Container1" , Vessel = vessel1 };
            Container container2 = new Container() { Name = "Container2", Vessel = vessel2 };

            context.Containers.Add(container1);
            context.Containers.Add(container2);

            context.SaveChanges();
        }
    }
}
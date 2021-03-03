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
            Vessel vessel = new Vessel() { Name = "Vessel1" };
            context.Vessels.Add(vessel);

            Container container1 = new Container() { Name = "Container1" , Vessel = vessel };
            Container container2 = new Container() { Name = "Container2", Vessel = vessel };

            context.Containers.Add(container1);
            context.Containers.Add(container2);

            context.SaveChanges();
        }
    }
}
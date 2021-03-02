using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FleetManagementService.Models;
using FleetManagementService.Models.Repositories;

namespace FleetManagementService.Controllers
{
    public class ContainersController : Controller
    {
        //FMSDataContext context = new FMSDataContext();
        ContainerRepository repository = new ContainerRepository();

        // GET: Containers
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Container container)
        {
            if (!ModelState.IsValid) return View(container);

            repository.Add(container);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
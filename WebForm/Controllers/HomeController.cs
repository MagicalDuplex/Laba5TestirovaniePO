using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebForm.Models;
using HumanResourcesDepartment;
using WebForm.Repository;

namespace WebForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkerContainer _es;

        public HomeController(IWorkerContainer es, ILogger<HomeController> logger)
        {
            _es = es;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult Operation(string submitButton, AddWorkerModel model)
        {
            switch (submitButton)
            {
                case "Add":
                    // delegate sending to another controller action
                    if (ModelState.IsValid)
                    {
                        _es.GetHumanDepartment().AddNewWorker(new Worker(model.addName, model.addSecondName,model.age,model.monthsWorkedOut,model.position,model.passport));
                    }

                    return RedirectToAction("Index");
                case "Remove":
                    _es.GetHumanDepartment().RemoveWithpassport(model.passport);

                    return RedirectToAction("Index");
                case "Update":
                    _es.GetHumanDepartment().UpdateWorkedOutHours(new Worker(model.addName, model.addSecondName, model.age, model.monthsWorkedOut, model.position, model.passport));


                    return RedirectToAction("Index");
                default:
                    
                    return (View());
            }
        }

        public IActionResult Index()
        {
            var found = _es.GetHumanDepartment();
            return View(found);
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using User;

namespace InsurancePolicyRegistration.Controllers
{
    public class InsuranceController : Controller
    {
        public readonly InsurancePolicyDbContext _db;
        public readonly ILogger<InsuranceController> _logger;

        public InsuranceController(InsurancePolicyDbContext db, ILogger<InsuranceController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            IEnumerable<InsurancePolicy> policyList = _db.InsiurancePolicies;
            return View(policyList);
        }


        //GET create
        [Authorize]
        public IActionResult Create()
        { 
            return View();
        }
        //POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InsurancePolicy obj)
        {
            if (ModelState.IsValid)
            {
                _db.InsiurancePolicies.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        
        //GET Delete
        [Authorize]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.InsiurancePolicies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }


        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.InsiurancePolicies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.InsiurancePolicies.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET Update
        [Authorize]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.InsiurancePolicies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        //POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(InsurancePolicy obj)
        {
            if (ModelState.IsValid)
            {
                _db.InsiurancePolicies.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

    }
}


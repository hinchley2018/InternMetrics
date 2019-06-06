using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternMetrics.Models;
using InternMetrics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternMetrics.Controllers
{
    [Route("Interns")]
    public class InternsController : Controller
    {
        // GET: Intern
        [Route("")]
        public ActionResult Index()
        {
            var internService = new InternService();
            var internList = internService.GetInterns().ToList();

            return View(internList);
        }

        // GET: Intern/Details/5
        [Route("[action]/{id}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("[action]")]
        // GET: Intern/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Intern/Create
        [Route("[action]")]
        [HttpPost]
        public ActionResult Create(string Name, string Email, string HomeState, string DesiredSkill)
        {
            try
            {
                var internService = new InternService();
                internService.CreateIntern(Name, Email, HomeState, DesiredSkill);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Intern/Edit/5
        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var internService = new InternService();
            var intern = internService.GetIntern(id);
            return View(intern);
        }

        // POST: Intern/Edit/5
        [Route("[action]/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm]IFormCollection collection)
        {
            try
            {
                var Name = collection["Name"];
                var Email = collection["Email"];
                var HomeState = collection["HomeState"];
                var DesiredSkill = collection["DesiredSkill"];
                var internService = new InternService();
                internService.EditIntern(id, Name, Email, HomeState, DesiredSkill);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Intern/Delete/5
        [Route("[action]/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var internService = new InternService();
                internService.DeleteIntern(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
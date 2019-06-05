﻿using System;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Intern/Edit/5
        [Route("/Edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Intern/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Intern/Delete/5
        [Route("/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Intern/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
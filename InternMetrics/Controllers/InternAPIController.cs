using System;
using System.Collections.Generic;
using System.Linq;
using InternMetrics.Models;
using InternMetrics.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternMetrics.Controllers
{
    [Route("api/[controller]")]
    public class InternAPIController : Controller
    {
        /// <summary>
        /// Gets the interns from the database
        /// </summary>
        /// <returns>Gets the interns from the database</returns>
        [HttpGet("[action]")]
        
        public IActionResult GetInterns()
        {
            var interns = new List<Intern>();
            InternService internService = new InternService();
            try
            {
                interns = internService.GetInterns().ToList();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Database error retrieving interns");
            }
            
            return Ok(interns);
        }
    }

    
}
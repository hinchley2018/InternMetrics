using System.Collections.Generic;
using InternMetrics.Models;
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
        public IEnumerable<Intern> GetInterns()
        {
            var interns = new List<Intern>();
            //TODO: get interns from the database

            return interns;
        }
    }

    
}
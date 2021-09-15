using DataHandle;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestDemo.Models;

namespace WebTestDemo.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController:ControllerBase
    {
        private DbReader dbReader = DbReader.Instance;
        
        [HttpGet]
        public IActionResult Get()
        {
            string sql = "select Users.* from Users";
            return new JsonResult(dbReader.Query<User>(sql));
        }
    }
}

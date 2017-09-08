using ConsumeCrude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConsumeCrude.Controllers.api
{
    public class SampleController : ApiController
    {

        [HttpPost]
        [Route("create")]
        public IHttpActionResult create(stud_Details s)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid student.");
            using (var context = new StudentEntities())
            {



                context.stud_Details.Add(new stud_Details()
                {
                    ID = s.ID,
                    Name = s.Name,
                    Age = s.Age

                });



                context.SaveChanges();
                return Ok("successfull");
            }
        }
    }
}

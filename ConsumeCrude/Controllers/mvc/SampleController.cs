using ConsumeCrude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsumeCrude.Controllers.mvc
{
    public class SampleController : Controller
    {

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(stud_Details student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60188//api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("student", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(student);
        }


    }
}

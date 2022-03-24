using AbhiApp.DBConnect;
using AbhiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbhiApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult AddStudent()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(StudentsModel sm)
        {
            StudentsEntities se = new StudentsEntities();

            stuData sd = new stuData();
            sd.name = sm.name;
            sd.email = sm.email;
            se.stuDatas.Add(sd);
            se.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public ActionResult ShowData()
        {

            StudentsEntities SE = new StudentsEntities();
            List<StudentsModel> sm = new List<StudentsModel>();

            var re = SE.stuDatas.ToList();

            foreach (var item in re)
            {
                sm.Add(new StudentsModel

                {
                    id = item.id,
                    name = item.name
                   ,
                    email = item.email
                });
            }

            return View(sm); 
        }


        public ActionResult IndexDashBoard()
        {


            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
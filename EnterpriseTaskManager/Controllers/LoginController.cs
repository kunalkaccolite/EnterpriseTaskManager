using EnterpriseTaskManager.DataAccess;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseTaskManager.Controllers
{
    public class LoginController : Controller
    {


        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ETMController etmControllerObj = new ETMController(new EventDAL());

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public bool ValidateUser(String userName, String password)
        {
            try
            {
                Session["userName"] = userName;
                return etmControllerObj.ValidateLogin(userName, password);
                         
            }
            catch(Exception e)
            {
                return false;
            }
        }

        [ChildActionOnly]
        public ActionResult GetHtmlPage(string path)
        {

            return new FilePathResult(path, "text/html");
        }
    }
}

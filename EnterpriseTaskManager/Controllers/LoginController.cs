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

     
       /// <summary>
       /// Validates the user Credentials
       /// </summary>
       /// <param name="userName"></param>
       /// <param name="password"></param>
       /// <returns></returns>
        public bool ValidateUser(String userName, String password)
        {
            try
            {
                Session["userName"] = userName;
                return etmControllerObj.ValidateLogin(userName, password);
            }
            catch(Exception e)
            {
                logger.Error(e, "Exception occured in Login Controller's ValidateUser Action");
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

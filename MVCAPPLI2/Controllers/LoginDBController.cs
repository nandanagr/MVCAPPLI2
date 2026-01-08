using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPPLI2.Models;
using System.Data.Entity.Core.Objects;

namespace MVCAPPLI2.Controllers
{
    public class LoginDBController : Controller
    {
        // GET: LoginDB
        MVCDB2Entities dbobj = new MVCDB2Entities();
        public ActionResult Login_pageload()
        {
            return View();
        }
        public ActionResult Login_click(LoginCls objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(objcls.Username, objcls.pwd,op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    Session["uname"] = objcls.Username;
                    return RedirectToAction("Home");
                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "Invalid Login";
                    return View("Login_pageload",objcls);
                }
            }
            return View("Login_pageload", objcls);
            //return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}
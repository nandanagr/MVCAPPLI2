using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPPLI2.Models;
using System.IO;

namespace MVCAPPLI2.Controllers
{
    public class InsertDBController : Controller
    {
        // GET: InsertDB
        MVCDB2Entities dbobj = new MVCDB2Entities();
        public ActionResult Insert_pageload()
        {
            List<stclass> stList = new List<stclass>
            {
                new stclass{sId=1,sName="Kannur"},
                new stclass{sId=2,sName="Kollam"},
                new stclass{sId=3,sName="Kochi" }
            };
            ViewBag.Selstates = new SelectList(stList, "sId", "sName");
            //return View();

            InsertCls user = new InsertCls();
            user.MyfavoriteQual = getQualificationData();
            return View(user);
        }

        public List<checkBoxListHelper> getQualificationData()
        {
            List<checkBoxListHelper> sts = new List<checkBoxListHelper>()
            {
                new checkBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new checkBoxListHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false},
                new checkBoxListHelper{Value="BCA",Text="BCA",IsChecked=false},
                new checkBoxListHelper{Value="B TECH",Text="B TECH",IsChecked=false},

            };
            return sts;
        }

        public ActionResult Insert_click(InsertCls clsobj,HttpPostedFileBase file,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/PHS");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\PHS", fname);
                    clsobj.Photo = fullpath;
                }


                List<stclass> stList = new List<stclass>
                    {
                        new stclass{sId=1,sName="Kannur"},
                        new stclass{sId=2,sName="Kollam"},
                        new stclass{sId=3,sName="Kochi" }
                    };
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                clsobj.MyfavoriteQual = getQualificationData();

                int selectedId = Convert.ToInt32(form["ddlstate"]);
                stclass selectedItem = stList.FirstOrDefault(c => c.sId == selectedId);
                clsobj.sId = selectedItem.sId;
                clsobj.sName = selectedItem.sName;

                clsobj.State = selectedItem.sName;

                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.Qual = quid;
                //clsobj.MyfavoriteQual = getQualificationData();

                dbobj.sp_insert(clsobj.Name, clsobj.Age, clsobj.Address, clsobj.Email, clsobj.Photo, clsobj.Gender, clsobj.State, clsobj.Qual, clsobj.Username, clsobj.Password);
                clsobj.msg = "Inserted successfully";
                return View("Insert_pageload",clsobj);
            }

            else
            {
                List<stclass> stList = new List<stclass>
                    {
                        new stclass{sId=1,sName="Kannur"},
                        new stclass{sId=2,sName="Kollam"},
                        new stclass{sId=3,sName="Kochi" }
                    };
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                clsobj.MyfavoriteQual = getQualificationData();
                return View("Insert_pageload", clsobj);
            }
           // return View("Insert_pageload", clsobj);

        }
    }
}
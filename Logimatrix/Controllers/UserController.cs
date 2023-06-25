using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logimatrix.Controllers
{
    public class UserController : Controller
    {
        TestEntities db = new TestEntities();
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(tblreg _reg)
        {
            
            db.tblregs.Add(_reg);
            db.SaveChanges();
           return RedirectToAction("RegistrationSuccess");
        }

        public ActionResult RegistrationSuccess()
        {
            
            return View();
        }

        public ActionResult AddProfile()
        {


           

            return View();

        }
        [HttpPost]
        public ActionResult AddProfile(tbladdprofile _addprof)
        {
            string filename = Path.GetFileNameWithoutExtension(_addprof.ImageFile.FileName);
            string extension = Path.GetExtension(_addprof.ImageFile.FileName);
            filename = filename + extension;
            _addprof.ProfileImage = "~/Images/"+filename;
            filename = Path.Combine(Server.MapPath("~/Images/"),filename);
            _addprof.ImageFile.SaveAs(filename);
            db.tbladdprofiles.Add(_addprof);
            db.SaveChanges();
            return View();
            
        }

        public ActionResult ShowProfile(tbladdprofile objprofile)
        {
            var data = db.tbladdprofiles.ToList();
            return View(data);
        }

        public ActionResult LogIn(tblreg objlogin)
        {
            var data = db.tblregs.Where(x => x.email.Equals(objlogin.email) && x.password.Equals(objlogin.password)).FirstOrDefault();
            if(data!=null)
            {
                return RedirectToAction("ShowProfile");
            }
            else
            {
            return View();
            }
            
        }
        
        public JsonResult ActiveProfile(int A)
        {
            var data = db.tbladdprofiles.Where(x => x.id == A).FirstOrDefault();/*ToList().Where(x => x.id == A)*/
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Miniproject.DataAccess;
using Miniproject.Models;

namespace Miniproject.Controllers
{
    public class clickColorsController : Controller
    {
        private MPContext db = new MPContext();

        // GET: clickColors
        public ActionResult Index()
        {
            // CATION !!!!! : Remove this when mainform created
            //Fake challange setp
            List<challengeStep> MySession = new List<challengeStep>();
            MySession.Add(new challengeStep {challengeType = 0, currentStep = 0, score = 0});

            Session["MySession"] = MySession;

            //Get rando color Row
            var randomColor = db.clickColors
                  .OrderBy(c => Guid.NewGuid())
                  .FirstOrDefault();

            ViewBag.rightColor = (clickColor)randomColor;
            Session["rightColor"] = ViewBag.rightColor.color;

            var unsortedColors = db.clickColors
                  .OrderBy(c => Guid.NewGuid())
                  .ToList();

            if (Session["Score"] == null)
            {
                Session["Score"] = 0;
            }

            return View(unsortedColors);
        }

     


        // GET: clickColors/Delete/5
        [HttpPost]
        public ActionResult Answer(string id, string command)
        {

            //Manage Session list and variables
            List<challengeStep> MySession;
            MySession = (List<challengeStep>) Session["MySession"];

            int temp_challengeType = MySession.Last().challengeType;
            int temp_currentStep = MySession.Last().currentStep;
            temp_currentStep++;
            //END Manage Session list and variables

            bool mySuccess = false;

            // If there is a match
            if (command == Session["rightColor"].ToString()) //wrong way
            {
                mySuccess = true;
                MySession.Add(new challengeStep { challengeType = temp_challengeType, currentStep = temp_currentStep, score = 1 });
                Session["Score"] = (int)Session["Score"] + 1;
            }
            else {// no match add 
                mySuccess = false;
                MySession.Add(new challengeStep { challengeType = temp_challengeType, currentStep = temp_currentStep, score = 0 });
            }

            Session["MySession"] = MySession;

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

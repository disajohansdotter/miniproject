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

            //return View((clickColor)randomColor);
            return View(db.clickColors.ToList());
        }

     


        // GET: clickColors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Answer(int? id)
        {

            //if (String.IsNullOrEmpty(p_answer))
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //Manage Session list and variables
            List<challengeStep> MySession;
            MySession = (List<challengeStep>) Session["MySession"];

            int temp_challengeType = MySession.Last().challengeType;
            int temp_currentStep = MySession.Last().currentStep;
            temp_currentStep++;
            //END Manage Session list and variables

            bool mySuccess;

            // If there is a match
            if (1 == 1) //wrong way
            {
                mySuccess = true;
                MySession.Add(new challengeStep { challengeType = temp_challengeType, currentStep = temp_currentStep, score = 1 });
            }
            else {// no match add 
                mySuccess = false;
                MySession.Add(new challengeStep { challengeType = temp_challengeType, currentStep = temp_currentStep, score = 0 });
            }

            Session["MySession"] = MySession;


            return Content(mySuccess.ToString());

            //return RedirectToRoute(new RouteAttribute()); // Add redictrect
            //return RedirectToAction("Index");
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

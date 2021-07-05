using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_base_donnee_indemnite.Models;

namespace test_base_donnee_indemnite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        private readonly DbContextIndimnite db;



        //login traitement

        public ActionResult Login()
        {
            //HttpContext.Session.SetString("nompersonnel", " ");
            //HttpContext.Session.SetInt32("idpersonnel", 0);
            //HttpContext.Session.SetString("isConnected", " ");

            Session["nomPersonnel"] = " ";
            Session["idpersonnel"] = 0;
            Session["isConnected"] = " ";


            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Personnel pers)
        {
            if(ModelState.IsValid)
            {
                using(DbContextIndimnite db = new DbContextIndimnite())
                {
                    var obj = db.personnels.Where(a => a.Username.Equals(pers.Username) && a.Password.Equals(pers.Password)).FirstOrDefault();
                    //ViewData.t = obj.Username;
                    if(obj != null)
                    {
                        Session["nomPersonnel"] = (obj.Nom + " " + obj.Prenom).ToString();
                        Session["idPersonnel"] = obj.IdPers.ToString();
                        //Session["isConnected"] = true;
                        return RedirectToAction("OrdreMissionList", "OrdreMission");
                    }

                    return View(pers);
                }
            }

            //return View();
            return RedirectToAction("OrdreMissionList", "OrdreMission");

        }


        [HttpPost]
        public ActionResult Authorize(Personnel pers)
        {

            Personnel userdetails = db.personnels.Where(a => a.Username.Equals(pers.Username) && a.Password.Equals(pers.Password)).FirstOrDefault();

            if (userdetails == null)
            {
                ViewBag.error = "Verifier vos information!";

                return View("Login");

            }
            else
            {

                if (CheckRole(userdetails) == 1)
                {
                    //HttpContext.Session.SetString("nompersonnel", userdetails.Nom + " " + userdetails.Prenom);
                    //HttpContext.Session.SetInt32("idpersonnel", userdetails.IdPers);
                    //HttpContext.Session.SetString("isConnected", "true");

                    Session["nomPersonnel"] = userdetails.Nom + " " + userdetails.Prenom;
                    Session["idPersonnel"] = userdetails.IdPers;
                    Session["isConnected"] = true;





                    return RedirectToAction("OrdreMissionList", "OrdreMission");

                }
                else if (CheckRole(userdetails) == 0)
                {

                    //HttpContext.Session.SetString("nomeconomique", userdetails.Nom + " " + userdetails.Prenom);
                    //HttpContext.Session.SetString("isConnected", "true");
                    

                    Session["nomeconomique"] = userdetails.Nom + " " + userdetails.Prenom;
                    Session["isConnected"] = true;
                    return RedirectToAction("OrdreMissionList", "OrdreMission");
                }
                else
                {
                    ViewBag.error = "les informations sont incorrect !";

                    return View("Login");
                }


            }


        }
        public int CheckRole(Personnel pers)
        {



            var userdetails = db.personnels.Where(a => a.Username == pers.Username && a.Password == pers.Password).FirstOrDefault();

            if (userdetails.Role == "personnel")
            {
                return 1;

            }
            else if (userdetails.Role == "economique")
            {
                return 0;

            }
            else
            {
                return -1;
            }


        }

        public ActionResult error()
        {
            return View();
        }
    }
}
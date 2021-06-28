using projet_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_base_donnee_indemnite.Models;

namespace test_base_donnee_indemnite.Controllers
{
    public class OrdrePaimentController : Controller
    {
        // GET: OrdrePaiment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrdrePaiment()
        {
            return View();
        }

        public ActionResult PrintOrdrePaiment()
        {
            string s0 = (string)Session["personnel"];
            String s1 = (string)Session["mois"];
            String s2 = (string)Session["annee"];

            String s3 = (string)Session["ov"];
            String s4 = (string)Session["bp"];

            int id = Convert.ToInt32(s0);
            int mois = Convert.ToInt32(s1);
            int annee = Convert.ToInt32(s2);

            int ov = Convert.ToInt32(s3);
            int bp = Convert.ToInt32(s4);

            DbContextIndimnite db = new DbContextIndimnite();
            Personnel p = db.personnels.Find(id);

            int art = 0;
            int and = 0;
            int lig = 0;

            char nomPersonnel = p.Nom[0];
            string prenomPersonnel = p.Prenom;

            if (p.Role.ToString() == "Personnel")
            {
                Parametre_paiement pm = db.param_paiement.Find(3);
                art = pm.Art;
                and = pm.num1;
                lig = pm.num2;
            }

            else if (p.Role == "Professeur")
            {
                Parametre_paiement pm = db.param_paiement.Find(5);
                art = pm.Art;
                and = pm.num1;
                lig = pm.num2;
            }

            ViewBag.ART = art;
            ViewBag.and = and;
            ViewBag.Lig = lig;

            ViewBag.ov = ov;
            ViewBag.bp = bp;

            ViewBag.nomPersonnel = nomPersonnel;
            ViewBag.prenomPersonnel = prenomPersonnel;


            return new Rotativa.ViewAsPdf("OrdrePaiment");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_base_donnee_indemnite.Models;

namespace test_base_donnee_indemnite.Controllers
{
    public class EtatIndKiloController : Controller
    {
        // GET: EtatIndKilo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EtatIndKilo()
        {
            //var moisMission = "";
            //DbContextIndimnite db = new DbContextIndimnite();
            //Personnel p = db.personnels.Find(id);
            //int moisDebut = p.DateDebut.Month;
            //int moisFin = p.DateFin.Month;

            //if (moisDebut == moisFin)
            //    moisMission = moisDebut.ToString();
            //else
            //    moisMission = moisDebut + " / " + moisFin;

            //DbContextIndimnite db = new DbContextIndimnite();
            //Personnel p = db.personnels.Find(id);
            DbContextIndimnite db = new DbContextIndimnite();

            string s0 = (string)Session["personnel"];
            String s1 = (string)Session["mois"];
            String s2 = (string)Session["annee"];

            Personnel p = db.personnels.Find(s0);

            ViewBag.personnel = p.Nom + " " + p.Prenom;
            ViewBag.mois = s1;
            ViewBag.annee = s2;

            return View();
        }

        public ActionResult PrintEtatIndKilo()
        {
            string s0 = (string)Session["personnel"];
            String s1 = (string)Session["mois"];
            String s2 = (string)Session["annee"];

            int id = Convert.ToInt32(s0);
            int mois = Convert.ToInt32(s1);
            int annee = Convert.ToInt32(s2);


            DbContextIndimnite db = new DbContextIndimnite();
            Personnel p = db.personnels.Find(id);
            var om = db.ordremission.Where(o => (o.dateDepart.Month == mois && o.IdPers == p.IdPers) || (o.dateDepart.Month == mois && o.IdPers == p.IdPers));
            var lastDayOfMonth = DateTime.DaysInMonth(annee, mois);

            int nbMission = om.Count();



            string motif = " ";
            int nbJ = 0;
            int dureeMission = 0;
            foreach (var item in om)
            {
                //if(item.dateDepart.Month == mois -1 && item.dateArrivee.Month == mois)

                if (item.dateDepart.Month == mois && item.dateArrivee.Month == mois)
                {
                    dureeMission = item.dateArrivee.Day - item.dateDepart.Day;
                }

                else if (item.dateDepart.Month == mois && item.dateArrivee.Month != mois)
                {
                    dureeMission = lastDayOfMonth - item.dateDepart.Day;
                }

                else if (item.dateDepart.Month != mois && item.dateArrivee.Month == mois)
                {
                    dureeMission = item.dateArrivee.Day;
                }

                nbJ = nbJ + dureeMission;
                //if (item.dateArrivee.Day <= lastDayOfMonth)
                //{
                //    motif = motif + ", " + item.objetDepart;
                //    dureeMission = item.dateArrivee.Day - item.dateDepart.Day;
                //    nbJ = nbJ + dureeMission;
                //}

            }



            int taux = 0;
            int total = 0;


            int nbJourForMission = 0;

            if (nbJ != 0)
            {
                if (p.echelon > 702)
                    taux = 100;
                else
                {
                    if (nbJourForMission <= 15)
                    {
                        if (p.Echelle >= 1 && p.Echelle <= 5)
                        {
                            //prixReaps = 30;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp5");
                            taux = param.valeur1;
                        }

                        else if (p.Echelle == 6 || p.Echelle == 7)
                        {
                            //prixReaps = 40;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp4");
                            taux = param.valeur1;

                        }

                        else if (p.Echelle >= 8 && p.Echelle <= 10 || p.Echelle == 0)
                        {
                            //prixReaps = 60;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp3");
                            taux = param.valeur1;
                        }

                        else if (p.Echelle == 11)
                        {
                            //prixReaps = 80;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp2");
                            taux = param.valeur1;
                        }



                        else
                        {
                            //prixReaps = 100;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp1");
                            taux = param.valeur1;
                        }
                    }

                    else
                    {
                        if (p.Echelle >= 1 && p.Echelle <= 5)
                        {
                            //prixReaps = 30;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp5");
                            taux = param.valeur2;
                        }

                        else if (p.Echelle == 6 || p.Echelle == 7)
                        {
                            //prixReaps = 40;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp4");
                            taux = param.valeur2;

                        }

                        else if (p.Echelle >= 8 && p.Echelle <= 10 || p.Echelle == 0)
                        {
                            //prixReaps = 60;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp3");
                            taux = param.valeur2;
                        }

                        else if (p.Echelle == 11)
                        {
                            //prixReaps = 80;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp2");
                            taux = param.valeur2;
                        }



                        else
                        {
                            //prixReaps = 100;
                            var param = db.parametre.FirstOrDefault(s => s.nom == "grp1");
                            taux = param.valeur2;
                        }
                    }


                }
            }

            int totalGlobal;
            total = taux * nbJ;
            totalGlobal = total * 3;


            //taux = prixReaps * nbJ;


            //ViewBag.test = om.GetType();

            ViewBag.personnel = p.Nom + " " + p.Prenom;
            ViewBag.echelle = p.Echelle;
            ViewBag.grade = p.NomGrades;
            ViewBag.residence = p.Adresse;
            ViewBag.groupe = p.echelon;
            ViewBag.motif = motif;
            ViewBag.mois = s1;
            ViewBag.annee = s2;
            ViewBag.nbJ = nbJ;
            ViewBag.taux = taux;
            ViewBag.total = total;
            ViewBag.totalGlobal = totalGlobal;
            return new Rotativa.ViewAsPdf("EtatIndKilo");
        }
    }
}
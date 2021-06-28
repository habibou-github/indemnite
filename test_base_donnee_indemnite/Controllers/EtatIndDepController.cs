using projet_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_base_donnee_indemnite.Models;

namespace test_base_donnee_indemnite.Controllers
{
    public class EtatIndDepController : Controller
    {
        // GET: EtatIndDep
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EtatIndDep()
        {
            return View();
        }

        public ActionResult PrintEtatIndDep()
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
            //int nbJ = 0;
            //int dureeMission = 0;

            if (nbMission > 0)
            {
                List<OrdreMission> ListMission = om.ToList();
                string voiturePersonnel = ListMission.First().matricule.ToString();
                int nbChevaux = Convert.ToInt32(ListMission.First().nombreCheuvaux);

                int idTrajet;
                int nbAlle = 0;
                int nbRetour = 0;
                int nbKilometre = 0;
                double taux = 0;
                double total = 0;

                foreach (var item in om)
                {
                    //if(item.dateDepart.Month == mois -1 && item.dateArrivee.Month == mois)

                    if (item.dateDepart.Month == mois && item.dateArrivee.Month == mois)
                    {
                        //dureeMission = item.dateArrivee.Day - item.dateDepart.Day;
                        idTrajet = item.id_trajet;
                        Trajet t = db.trajet.Find(idTrajet);
                        nbKilometre = nbKilometre + t.distance * 2;
                        motif = motif + ", " + item.objetDepart;
                        nbAlle++;
                        nbRetour++;
                    }

                    else if (item.dateDepart.Month == mois && item.dateArrivee.Month != mois)
                    {
                        //dureeMission = lastDayOfMonth - item.dateDepart.Day;
                        idTrajet = item.id_trajet;
                        Trajet t = db.trajet.Find(idTrajet);
                        nbKilometre = nbKilometre + t.distance;
                        motif = motif + ", " + item.objetDepart;
                        nbAlle++;
                    }

                    else if (item.dateDepart.Month != mois && item.dateArrivee.Month == mois)
                    {
                        //dureeMission = item.dateArrivee.Day;
                        idTrajet = item.id_trajet;
                        Trajet t = db.trajet.Find(idTrajet);
                        nbKilometre = nbKilometre + t.distance;
                        motif = motif + ", " + item.objetDepart;
                        nbRetour++;
                    }

                    Parametre_voiture paramV1 = db.param_voiture.Find(1);
                    Parametre_voiture paramV2 = db.param_voiture.Find(3);
                    Parametre_voiture paramV3 = db.param_voiture.Find(4);

                    if (nbChevaux > paramV1.nombre_cheveau_min && nbChevaux <= paramV1.nombre_cheveau_max)
                    {
                        taux = paramV1.prix_par_km;
                        total = nbKilometre * taux;

                    }



                    else if (nbChevaux >= paramV2.nombre_cheveau_min && nbChevaux <= paramV2.nombre_cheveau_max)
                    {
                        taux = paramV2.prix_par_km;
                        total = nbKilometre * taux;
                    }

                    else if (nbChevaux >= paramV3.nombre_cheveau_min && nbChevaux <= paramV3.nombre_cheveau_max)
                    {
                        taux = paramV3.prix_par_km;
                        total = nbKilometre * taux;
                    }



                    //nbJ = nbJ + dureeMission;
                    //if (item.dateArrivee.Day <= lastDayOfMonth)
                    //{
                    //    motif = motif + ", " + item.objetDepart;
                    //    dureeMission = item.dateArrivee.Day - item.dateDepart.Day;
                    //    nbJ = nbJ + dureeMission;
                    //}

                }

                ViewBag.personnel = p.Nom + " " + p.Prenom;
                ViewBag.echelle = p.Echelle;
                ViewBag.grade = p.NomGrades;
                ViewBag.residence = p.Adresse;
                ViewBag.groupe = p.echelon;
                ViewBag.motif = motif;
                ViewBag.mois = s1;
                ViewBag.annee = s2;

                ViewBag.voiturePersonnel = voiturePersonnel;
                ViewBag.nbChevaux = nbChevaux;
                ViewBag.nbKilometre = nbKilometre;
                ViewBag.taux = taux;
                ViewBag.total = total;
                ViewBag.nbAlle = nbAlle;
                ViewBag.nbRetour = nbRetour;
            }

            //else
            //{
            //    ViewBag.alertError = "Le mois choisi ne correspond à aucun ordre de mission";
            //    return Redirect(Url.Action("Index", "HomePage", ViewBag.alertError));
            //}



            return new Rotativa.ViewAsPdf("EtatIndDep");


        }
    }
}
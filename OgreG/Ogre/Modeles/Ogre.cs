using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogre.Modeles
{
    public enum Strats
    {
        Ours,
        Loup,
        Chevreuil,
        Impatient
    }
    public class Ogre
    {
        public Action<int> Dormir { get; set; }
        public Action<Ogre> Observateurs { get; set; }
        private static object lock1 = new object();

        public int OgreID { get; set; }
        public string Nom { get; set; }
        public Strats Strategie { get; set; }
        public bool Mange { get; set; }
        public Plat PlatManger { get; set; }
        public CuisineEtOgreContext context { get; set; }

        public Ogre(string nom, Strats strats)
        {
            Nom = nom;
            Mange = false;
            Strategie = strats;
            context = new CuisineEtOgreContext();
        }
        public Ogre()
        {
        }

        public void MangerPlat(Ogre ogre)
        {
            while (true)
            {
                Plat plat = null;
                lock (lock1)
                {
                    if (ogre.Mange == false)
                    {
                        switch (ogre.Strategie)
                        {
                            case Strats.Ours:
                                plat = OursStrats(context);
                                break;
                            case Strats.Loup:
                                plat = LoupStrats(context);
                                break;
                            case Strats.Chevreuil:
                                plat = ChrevreuilStrats(context);
                                break;
                            case Strats.Impatient:
                                plat = ImpatientStrats(context);
                                break;
                            default:
                                break;
                        };
                        PlatManger = plat;
                        if (plat != null)
                        {

                            plat.Vide = true;
                            ogre.Mange = true;
                            Observateurs?.Invoke(this);
                            RetirerPlat(context,plat);
                        }
                    }
                }
                if (plat != null)
                {
                    Thread.Sleep(plat.TaillePlatMoyen * 1000);
                    Console.WriteLine($"L'Ogre {ogre.Nom} a terminé son plat !");
                    ogre.Mange = false;
                }
                Thread.Sleep(1000);
            }
        }
        public void RetirerPlat(CuisineEtOgreContext context,Plat plat)
        {
            context.Plats.Remove(plat);
            context.SaveChanges();
        }
        //Stratégie De L'Ours 
        public Plat OursStrats(CuisineEtOgreContext context)
        {
            Plat plat = context.Plats.OrderByDescending(plat => plat.TaillePlatMoyen).FirstOrDefault();
            return plat;
        }
        //Stratégie Du Loups
        public Plat LoupStrats(CuisineEtOgreContext context)
        {
            Plat plat = Sucre(context);

            if (plat == null)
            {
                plat = context.Plats.Where(plat => plat.Type == "Carnivore").FirstOrDefault();
            }

            return plat;
        }
        //Stratégie du Chevreuil 
        public Plat ChrevreuilStrats(CuisineEtOgreContext context)
        {
            Plat plat = Sucre(context);

            if (plat == null)
            {
                plat = context.Plats.Where(plat => plat.Type == "Vegetarien").FirstOrDefault();
            }

            return plat;
        }

        //Recherche Sucrerie
        public Plat Sucre(CuisineEtOgreContext context)
        {
            Plat plat = context.Plats.Where(plat => plat.Type == "Sucrerie").FirstOrDefault();
            return plat;
        }

        //Stratégie DE L'Impatient<
        public Plat ImpatientStrats(CuisineEtOgreContext context)
        {
            Plat plat = null;
            plat = context.Plats.OrderBy(plat => plat.TempsMoyenPreparationPlat).FirstOrDefault();
            return plat;
        }

    }
}

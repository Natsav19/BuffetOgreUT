using Cuisine.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine
{
    public class Cuisine
    {
        public CuisineContext context { get; set; }
        public void Run()
        {
            CuisineContext context = new CuisineContext();
            while (true)
            {
                //Setting des différents Type de Plats
                TypePlat vege = new TypePlat("Vegetarien", 5);
                TypePlat carnivore = new TypePlat("Carnivore", 4);
                TypePlat sucre = new TypePlat("Sucrerie", 1);
                if (!context.TypePlats.Any())
                {
                    //Ajout dans table
                    context.TypePlats.Add(vege);
                    context.TypePlats.Add(carnivore);
                    context.TypePlats.Add(sucre);
                }
                //---Randomiser---//

                Random rnd = new Random();
                int nbRdm = rnd.Next(0, 10);

                //---------------//
                //Setting du type de plats pour la création du plat
                Plats plat;
                if (nbRdm <= 5) { plat = new Plats(vege); }
                else if (nbRdm <= 9 && nbRdm > 5) { plat = new Plats(carnivore); }
                else { plat = new Plats(sucre); }

                int tempsprepa = 0;
                while (tempsprepa != plat.Temps_Moyen_Preparation_Plat)
                {
                    Console.WriteLine("Plat en préparation");
                    tempsprepa++;
                }
                Console.WriteLine(plat.ToString());
                AjouterPlat(plat);

            }
            Console.ReadKey();
        }
        public void AjouterPlat(Plats plat)
        {
            context.Plat.Add(plat);
            context.SaveChanges();
        }
    }
}

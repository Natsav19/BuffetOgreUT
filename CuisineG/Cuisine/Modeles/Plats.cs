using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Modeles
{
    public class Plats
    {
        private readonly Random rnd;

        public int PlatsID { get; set; }
        public int Temps_Moyen_Preparation_Plat { get; set; }
        public int Taille_Plat_Moyen { get; set; }
        public bool Vide { get; set; }
        public string Type { get; set; }

        //Constructeur Vide :) 
        public Plats()
        {
        }
        //Constructeur Seulement Type 
        public Plats(TypePlat type)
        {
            //Randomiser
            Random rnd = new Random();

            Temps_Moyen_Preparation_Plat = (int)(-1 * (2 - 1) * Math.Log(1 - rnd.NextDouble())) + 1; 
            Taille_Plat_Moyen = (int)(-1 * (5 - 1) * Math.Log(1 - rnd.NextDouble())) + 1;

            Vide = Taille_Plat_Moyen <= 0;
            Type = type.NomType;
        }

        //Constructeur Avec Envoie de Random 
        public Plats(TypePlat type, Random random)
        {
            Random rnd = new Random();

            Temps_Moyen_Preparation_Plat = (int)(-1 * (2 - 1) * Math.Log(1 - random.NextDouble())) + 1;
            Taille_Plat_Moyen = (int)(-1 * (5 - 1) * Math.Log(1 - random.NextDouble())) + 1;

            Vide = Taille_Plat_Moyen <= 0;
            Type = type.NomType;
        }
        
        //Constructeur Avec Tout
        public Plats(TypePlat type, int temps , int taille)
        {
            Temps_Moyen_Preparation_Plat = temps ;
            Taille_Plat_Moyen = taille;

            Vide = Taille_Plat_Moyen <= 0;
            Type = type.NomType;
        }


        public override string ToString()
        {
            return $" Un nouveau plat a été servit en {Temps_Moyen_Preparation_Plat} secondes, Il a un Taille de {Taille_Plat_Moyen} bouchée  Bonne appétits ! ";
        }
    }
}

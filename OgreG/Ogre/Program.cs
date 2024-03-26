using Microsoft.IdentityModel.Tokens;
using Ogre.Modeles;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ogre
{
    public class Program
    {
        static void Main(string[] args)
        {
           Program program = new Program();
           program.Demarrer();
        }
        public async void Demarrer()
        {
            List<Modeles.Ogre> ogres = new List<Modeles.Ogre>
            {
                new Modeles.Ogre("Sami", Strats.Ours),
                new Modeles.Ogre("Jerome", Strats.Loup),
                new Modeles.Ogre("Louis", Strats.Chevreuil),
                new Modeles.Ogre("Nathan", Strats.Impatient)
            };
            foreach (Modeles.Ogre o in ogres)
                o.Observateurs += Imprimer;
            Task sami = Task.Run(() => ogres[0].MangerPlat(ogres[0]));
            Task jerome = Task.Run(() => ogres[1].MangerPlat(ogres[1]));
            Task louis = Task.Run(() => ogres[2].MangerPlat(ogres[2]));
            Task Nathan = Task.Run(() => ogres[3].MangerPlat(ogres[3]));
            Task.WaitAll(sami, jerome, louis, Nathan);
            Console.ReadKey();
        }
        public void Imprimer(Modeles.Ogre ogre) 
        {
            Console.WriteLine($"L'Ogre {ogre.Nom} a choisi un plat {ogre.PlatManger.Type}. Il va lui falloir {ogre.PlatManger.TaillePlatMoyen} bouchées pour le terminer. {ogre.PlatManger.TempsMoyenPreparationPlat}");
        }
    }
}


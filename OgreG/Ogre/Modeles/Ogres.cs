using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogre.Modeles
{
    public class Ogres
    {
        public int OgreID { get; set; }
        public string Nom { get; set; }
        public bool Mange { get; set; }
        
        public Ogres(string nom)
        {
            Nom = nom;
            Mange = false;
        }
    }
}

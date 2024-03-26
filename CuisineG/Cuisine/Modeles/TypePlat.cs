using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Modeles
{
    public class TypePlat 
    {
        public int TypePlatID { get; set; }
        public string NomType { get; set; }
        public int Chance { get; set; }

        public TypePlat()
        {
        }
        public TypePlat(string nom, int probabilite) 
        {
            NomType = nom;
            Chance = probabilite;
        }

    }

}

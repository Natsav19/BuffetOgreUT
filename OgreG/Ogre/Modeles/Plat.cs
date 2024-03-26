using System;
using System.Collections.Generic;

namespace Ogre.Modeles
{
    public partial class Plat
    {
        public int PlatsId { get; set; }
        public int TempsMoyenPreparationPlat { get; set; }
        public int TaillePlatMoyen { get; set; }
        public bool Vide { get; set; }
        public string Type { get; set; } = null!;
    }
}

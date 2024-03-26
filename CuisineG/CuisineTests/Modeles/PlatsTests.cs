using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuisine.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Cuisine.Modeles.Tests
{
    [TestClass()]
    public class PlatsTests
    {
        List<Plats> mesPlats;

        [TestInitialize]
        public void ConstruireTout()
        {
            mesPlats = new List<Plats> {
                new Plats { Taille_Plat_Moyen = 10,Type = "Vegetarien"},
                new Plats { Taille_Plat_Moyen = 8, Type = "Vegetarien"},
                new Plats { Taille_Plat_Moyen = 3, Type = "Carnivore"},
            };
        }

        [TestMethod()]
        public void PlatsTest()
        {
            TypePlat type = new TypePlat("TestType", 1);
            Plats LeBonPlat = new Plats( type , 1 , 3 );

            var mockRandom = new Mock<Random>();
            mockRandom.Setup(r => r.NextDouble()).Returns(0.5); 

            Plats plat = new Plats(type, mockRandom.Object);

            Assert.AreEqual(plat.Type, LeBonPlat.Type);
            Assert.AreEqual(plat.Taille_Plat_Moyen, LeBonPlat.Taille_Plat_Moyen);
            Assert.AreEqual(plat.Temps_Moyen_Preparation_Plat, LeBonPlat.Temps_Moyen_Preparation_Plat);

        }
        [TestMethod()]
        public void AjouterPlatsTest()
        {
            var mockContexte = new Mock<CuisineContext>();
            mockContexte.Setup(p => p.Plat).ReturnsDbSet(mesPlats);
            Cuisine c = new Cuisine { context = mockContexte.Object };
            Plats platDeFou = new Plats();


            c.AjouterPlat(platDeFou);

            mockContexte.Verify(m => m.Plat.Add(platDeFou), Times.Once);
            mockContexte.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}


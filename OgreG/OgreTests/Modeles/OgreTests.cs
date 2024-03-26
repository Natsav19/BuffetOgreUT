using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Bson;
using Ogre.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;


namespace Ogre.Modeles.Tests
{
    [TestClass()]
    public class OgreTests
    {
        List<Plat> mesPlats;

        [TestInitialize]
        public void ConstruireTout()
        {
            mesPlats = new List<Plat> {
                new Plat { TaillePlatMoyen = 10,Type = "Vegetarien"},
                new Plat { TaillePlatMoyen = 8, Type = "Vegetarien"},
                new Plat { TaillePlatMoyen = 3, Type = "Carnivore"},
            };
        }

        [TestMethod()]
        public void OursStratsTest()
        {
            Plat lePlatChoisit= mesPlats.OrderByDescending(plat => plat.TaillePlatMoyen).FirstOrDefault();

            int tailleMax = mesPlats.Max(plat => plat.TaillePlatMoyen);

            Assert.AreEqual(tailleMax, lePlatChoisit.TaillePlatMoyen);
        }
        [TestMethod()]
        public void LoupStratsTest()
        {
            Plat lePlatChoisit = mesPlats.Where(plat => plat.Type == "Sucrerie" || plat.Type == "Carnivore").OrderByDescending(plat => plat.Type).FirstOrDefault();
            if (lePlatChoisit.Type == "Carnivore")
            {
                Assert.AreEqual("Carnivore", lePlatChoisit.Type);
            }
            else
            {
                Assert.AreEqual("Sucrerie", lePlatChoisit.Type);
            }
        }
        [TestMethod()]
        public void ChrevreuilStratsTest()
        {
            Plat lePlatChoisit = mesPlats.Where(plat => plat.Type == "Sucrerie" || plat.Type == "Vegetarien").OrderBy(plat => plat.Type).FirstOrDefault();
            if(lePlatChoisit.Type == "Vegetarien")
            {
                Assert.AreEqual("Vegetarien", lePlatChoisit.Type);
            }
            else
            {
                Assert.AreEqual("Sucrerie", lePlatChoisit.Type);
            }
        }
        [TestMethod()]
        public void ImpatientStratsTest()
        {
            Plat lePlatChoisit = mesPlats.OrderBy(plat => plat.TempsMoyenPreparationPlat).FirstOrDefault();

            int tailleMin = mesPlats.Min(plat => plat.TempsMoyenPreparationPlat);

            Assert.AreEqual(tailleMin, lePlatChoisit.TempsMoyenPreparationPlat);
        }

        [TestMethod()]
        public void RetirerPlatTest()
        {
            var mockContext = new Mock<CuisineEtOgreContext>();
            mockContext.Setup(p => p.Plats).ReturnsDbSet(mesPlats);
            Modeles.Ogre ogre = new()
            {
                context = mockContext.Object
            };

            Plat platSuperBon = new Plat();
            var mockDormir = new Mock<Action<int>>();

            ogre.RetirerPlat(ogre.context, platSuperBon);

            mockContext.Verify(m => m.Plats.Remove(platSuperBon), Times.Once);
            mockContext.Verify(m => m.SaveChanges());
        }

    }
}
using NUnit.Framework;

namespace roleplay
{
    public class TestElfo
    {
        private Elfo elfo;
        private Item masterSword;
        private Item escudoHyliano;

        [SetUp]
        public void Setup()
        {
            elfo = new Elfo("Link");
            masterSword = Item.MasterSword;
            escudoHyliano = Item.EscudoHyliano;
        }

        [Test]
        public void TestInicializacionElfo()
        {
            Assert.AreEqual("Link", elfo.Nombre);
            Assert.AreEqual(200, elfo.Vida);
            Assert.AreEqual(20, elfo.Ataque);
            Assert.AreEqual(100, elfo.Mana);
        }

        [Test]
        public void TestCargarMana()
        {
            var resultado = elfo.RecargaMana(50);
            Assert.AreEqual("Aumentaste el mana en 50 puntos", resultado);
            Assert.AreEqual(150, elfo.Mana);

            resultado = elfo.RecargaMana(200);
            Assert.AreEqual("El maná está al maximo", resultado);
        }

        [Test]
        public void TestAgregarItem()
        {
            elfo.AgregarItem(masterSword);
            elfo.AgregarItem(escudoHyliano);
            Assert.AreEqual(2, elfo.Item.Count);
        }

        [Test]
        public void TestCuracion()
        {
            elfo.Vida = 180;
            elfo.Curacion(15);
            Assert.AreEqual(195, elfo.Vida);

            elfo.Curacion(25);
            Assert.AreEqual(195, elfo.Vida); 
        }

        [Test]
        public void TestAtacarConItem()
        {
            elfo.AgregarItem(masterSword);
            int valorAtaque = elfo.Atacar(item: masterSword);
            Assert.AreEqual(60, valorAtaque); // 20 + 40 (Master Sword)
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            elfo.Defender(40, "Bokoblin");
            Assert.AreEqual(160, elfo.Vida); 
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            elfo.AgregarItem(escudoHyliano);
            elfo.Defender(60, "Bokoblin");
            Assert.AreEqual(190, elfo.Vida); // 60 daño, 60 defensa del Escudo Hyliano
        }
    }
}

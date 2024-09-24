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
            Assert.That( elfo.Nombre,Is.EqualTo("Link"));
            Assert.That( elfo.Vida,Is.EqualTo(200));
            Assert.That( elfo.Ataque,Is.EqualTo(20));
            Assert.That( elfo.Mana,Is.EqualTo(100));
        }

        [Test]
        public void TestCargarMana()
        {
            var resultado = elfo.RecargaMana(50);
            Assert.That(resultado, Is.EqualTo("Aumentaste el mana en 50 puntos"));
            Assert.That(elfo.Mana, Is.EqualTo(150));

            resultado = elfo.RecargaMana(200);
            Assert.That(resultado, Is.EqualTo("El maná está al maximo"));
        }

        [Test]
        public void TestAgregarItem()
        {
            elfo.AgregarItem(masterSword);
            elfo.AgregarItem(escudoHyliano);
            Assert.That(elfo.Item.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestCuracion()
        {
            elfo.Vida = 180;
            elfo.Curacion(15);
            Assert.That(elfo.Vida, Is.EqualTo(195));

            elfo.Curacion(25);
            Assert.That(elfo.Vida, Is.EqualTo(195));
        }

        [Test]
        public void TestAtacarConItem()
        {
            elfo.AgregarItem(masterSword);
            int valorAtaque = elfo.AtacarConItems(item: masterSword);
            Assert.That(valorAtaque, Is.EqualTo(60)); // 20 + 40 (Master Sword)
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            elfo.Defender(40, "Bokoblin");
            Assert.That(elfo.Vida, Is.EqualTo(160));
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            elfo.AgregarItem(escudoHyliano);
            elfo.Defender(60, "Bokoblin");
            Assert.That(elfo.Vida, Is.EqualTo(190)); // 60 daño, 60 defensa del Escudo Hyliano
        }
    }
}

using NUnit.Framework;

namespace roleplay
{
    public class TestMago
    {
        private Mago mago;
        private Item tunicaZora;
        private Habilidades ziodyne;
        private Habilidades agi;

        [SetUp]
        public void Setup()
        {
            mago = new Mago("Zelda");
            tunicaZora = Item.TunicaZora;
            ziodyne = Habilidades.Ziodyne;
            agi = Habilidades.Agi;
        }

        [Test]
        public void TestInicializacionMago()
        {
            Assert.That(mago.Nombre, Is.EqualTo("Zelda"));
            Assert.That(mago.Vida, Is.EqualTo(150));
            Assert.That(mago.Mana, Is.EqualTo(100));
            Assert.That(mago.Ataque, Is.EqualTo(20));
        }

        [Test]
        public void TestAgregarHabilidad()
        {
            mago.AgregarHabilidad(ziodyne);
            mago.AgregarHabilidad(agi);
            Assert.That(mago.Habilidades.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestAtacarConHabilidad()
        {
            mago.AgregarHabilidad(agi);
            int valorAtaque = mago.AtacarConHabilidades(habilidades: agi);
            Assert.That(valorAtaque, Is.EqualTo(50)); // 20 (base) + 30 (Agi)

        }

        [Test]
        public void TestDefender()
        {
            mago.AgregarItem(tunicaZora);
            mago.Defender(50, "Rey Bulblin");
            Assert.That(mago.Vida, Is.EqualTo(120)); // 150 - 50 + 20 (defensa túnica)
        }

        [Test]
        public void TestRecargaMana()
        {
            var resultado = mago.RecargaMana(50);
            Assert.That(resultado, Is.EqualTo("Aumentaste el mana en 50 puntos"));
            Assert.That(mago.Mana, Is.EqualTo(150));

            resultado = mago.RecargaMana(200);
            Assert.That(resultado, Is.EqualTo("El maná está al maximo"));

        }
    }
}
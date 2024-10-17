using NUnit.Framework;

namespace roleplay
{
    public class TestEnano
    {
        private Enano enano;
        private Item botasDeHierro;
        private Item tunicaZora;

        [SetUp]
        public void Setup()
        {
            enano = new Enano("Darunia");
            botasDeHierro = Item.BotasDeHierro;
            tunicaZora = Item.TunicaZora;
        }

        [Test]
        public void TestInicializacionEnano()
        {
            Assert.That(enano.Nombre, Is.EqualTo("Darunia"));
            Assert.That(enano.Vida, Is.EqualTo(250));
            Assert.That(enano.Ataque, Is.EqualTo(50));
        }

        [Test]
        public void TestAgregarItem()
        {
            enano.AgregarItem(botasDeHierro);
            enano.AgregarItem(tunicaZora);
            Assert.That(enano.Item.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestAtacarConItems()
        {
            enano.AgregarItem(botasDeHierro);
            int valorAtaque = enano.AtacarConItems(botasDeHierro);
            Assert.That(valorAtaque, Is.EqualTo(50)); // Ataque base sin incremento
        }

        [Test]
        public void TestDefender()
        {
            enano.AgregarItem(botasDeHierro);
            enano.AgregarItem(tunicaZora);
            enano.Defender(100, "Molduga");
            Assert.That(enano.Vida, Is.EqualTo(200)); // 250 - 100 + (30+20) defensa
        }
    }
}
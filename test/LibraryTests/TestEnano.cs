using NUnit.Framework;

namespace roleplay;

public class TestEnano
{
    private Enano enano;
    private IItemAtaque espadaBiggoron;
    private IItemDefensa botasDeHierro;
    private IItemDefensa tunicaZora;

    [SetUp]
    public void Setup()
    {
        enano = new Enano("Darunia");
        espadaBiggoron = Item.EspadaBiggoron;
        botasDeHierro = Item.BotasDeHierro;
        tunicaZora = Item.TunicaZora;
    }

    [Test]
    public void TestInicializacionEnano()
    {
        Assert.That(enano.Nombre, Is.EqualTo("Darunia"));
        Assert.That(enano.Vida, Is.EqualTo(200));
        Assert.That(enano.Ataque, Is.EqualTo(20));
    }

    [Test]
    public void TestAgregarItemAtaque()
    {
        enano.AgregarItemAtaque(espadaBiggoron);
        Assert.That(enano.ItemAtaque.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestAgregarItemDefensa()
    {
        enano.AgregarItemDefensa(botasDeHierro);
        enano.AgregarItemDefensa(tunicaZora);
        Assert.That(enano.ItemDefensa.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestAtacarConItems()
    {
        enano.AgregarItemAtaque(espadaBiggoron);
        int valorAtaque = enano.AtacarConItems(espadaBiggoron);
        Assert.That(valorAtaque, Is.EqualTo(20 + espadaBiggoron.Ataque));
    }

    [Test]
    public void TestDefender()
    {
        enano.AgregarItemDefensa(botasDeHierro);
        enano.Defender(50, "Molduga");
        Assert.That(enano.Vida, Is.EqualTo(200 - 50 + botasDeHierro.Defensa));
    }

    [Test]
    public void TestVidaNoSobrepasaMaximo()
    {
        enano.Vida = 180;
        enano.CurarVida(30);
        Assert.That(enano.Vida, Is.EqualTo(200));
    }

    [Test]
    public void TestRecibirAtaqueSinDefensa()
    {
        enano.Defender(30, "Molduga");
        Assert.That(enano.Vida, Is.EqualTo(200 - 30));
    }
}
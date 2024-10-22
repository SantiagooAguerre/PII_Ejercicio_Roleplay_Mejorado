using NUnit.Framework;

namespace roleplay;

public class TestGanondorf
{
    private Ganondorf ganondorf;

    [SetUp]
    public void Setup()
    {
        ganondorf = new Ganondorf("Ganondorf", false);
    }

    [Test]
    public void TestInicializacionGanondorf()
    {
        Assert.That(ganondorf.Nombre, Is.EqualTo("Ganondorf"));
        Assert.That(ganondorf.Vida, Is.EqualTo(200));
        Assert.That(ganondorf.Vidabase, Is.EqualTo(200));
        Assert.That(ganondorf.Ataque, Is.EqualTo(20));
    }

    [Test]
    public void TestInicializacionGanondorfFormaFinal()
    {
        var ganondorfFinal = new Ganondorf("Ganondorf", true);
        Assert.That(ganondorfFinal.Nombre, Is.EqualTo("Ganondorf -Forma Final-"));
        Assert.That(ganondorfFinal.Vida, Is.EqualTo(230));
        Assert.That(ganondorfFinal.Vidabase, Is.EqualTo(230));
        Assert.That(ganondorfFinal.Ataque, Is.EqualTo(70));
    }
}
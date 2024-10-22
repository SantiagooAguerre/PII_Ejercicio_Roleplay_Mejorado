namespace roleplay;

using NUnit.Framework;

public class TestBokoblin
{
    private Bokoblin Bokoblin;

    [SetUp]
    public void Setup()
    {
        Bokoblin = new Bokoblin("Ganon");
    }

    [Test]
    public void TestInicializacionBokoblin()
    {
        Assert.That(Bokoblin.Nombre, Is.EqualTo("Ganon"));
        Assert.That(Bokoblin.Vida, Is.EqualTo(200));
        Assert.That(Bokoblin.Ataque, Is.EqualTo(20));
    }

    [Test]
    public void TestRecibirAtaqueFisico()
    {
        var output = CaptureConsoleOutput(() => Bokoblin.RecibirAtaqueFisico(30, "Link"));
        Assert.That(output, Is.EqualTo("Ganon es inmune a los ataques físicos. El ataque de Link no tuvo efecto.\n"));
        Assert.That(Bokoblin.Vida, Is.EqualTo(200));
    }

    [Test]
    public void TestRecibirAtaqueMagico()
    {
        Bokoblin.RecibirAtaqueMagico(50, "Zelda");
        Assert.That(Bokoblin.Vida, Is.EqualTo(150));
    }

    [Test]
    public void TestRecibirAtaqueMagicoYVerificarMuerte()
    {
        Bokoblin.RecibirAtaqueMagico(200, "Zelda");
        Assert.That(Bokoblin.Vida, Is.EqualTo(-50));
    }

    private string CaptureConsoleOutput(Action action)
    {
        var sw = new StringWriter();
        Console.SetOut(sw);
        action();
        return sw.ToString();
    }
}
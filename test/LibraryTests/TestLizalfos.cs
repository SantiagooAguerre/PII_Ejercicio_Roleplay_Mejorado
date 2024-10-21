using NUnit.Framework;

namespace roleplay;

public class TestLizalfos
{
    private Lizalfos lizalfos;

    [SetUp]
    public void Setup()
    {
        lizalfos = new Lizalfos("Zelda");
    }

    [Test]
    public void TestInicializacionLizalfos()
    {
        Assert.That(lizalfos.Nombre, Is.EqualTo("Zelda"));
        Assert.That(lizalfos.Vida, Is.EqualTo(200));
        Assert.That(lizalfos.Vidabase, Is.EqualTo(200));
        Assert.That(lizalfos.Ataque, Is.EqualTo(20));
    }

    [Test]
    public void TestRecibirAtaqueFisico()
    {
        lizalfos.RecibirAtaqueFisico(30, "Link");
        Assert.That(lizalfos.Vida, Is.EqualTo(170)); // Verifica que la vida disminuya correctamente
    }

    [Test]
    public void TestRecibirAtaqueFisicoYVerificarMuerte()
    {
        lizalfos.RecibirAtaqueFisico(200, "Link"); // Ataque que debería matar al Lizalfos
        Assert.That(lizalfos.Vida, Is.EqualTo(-30)); // Verifica que la vida sea -30
    }

    [Test]
    public void TestRecibirAtaqueMagico()
    {
        var output = CaptureConsoleOutput(() => lizalfos.RecibirAtaqueMagico(50, "Zelda"));
        Assert.That(output, Is.EqualTo("Zelda es inmune a los ataques magicos. El ataque de Zelda no tuvo efecto.\n"));
        Assert.That(lizalfos.Vida, Is.EqualTo(200)); // La vida no debe cambiar
    }

    private string CaptureConsoleOutput(Action action)
    {
        var sw = new StringWriter();
        Console.SetOut(sw);
        action();
        return sw.ToString();
    }
}
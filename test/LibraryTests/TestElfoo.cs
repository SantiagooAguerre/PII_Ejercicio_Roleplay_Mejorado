using NUnit.Framework;

namespace roleplay;

public class TestElfo
{
    private Elfo elfo;
    private IItemMagico infilitracion;

    [SetUp]
    public void Setup()
    {
        elfo = new Elfo("Link");
        infilitracion = Item.Infilitracion;
    }

    [Test]
    public void TestInicializacionElfo()
    {
        Assert.That(elfo.Nombre, Is.EqualTo("Link"));
        Assert.That(elfo.Vida, Is.EqualTo(200));
        Assert.That(elfo.Ataque, Is.EqualTo(20));
        Assert.That(elfo.Mana, Is.EqualTo(100));
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
    public void TestAgregarItemMagico()
    {
        elfo.AgregarItemMagico(infilitracion);
        Assert.That(elfo.ItemMagico.Count, Is.EqualTo(1));
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
    public void TestAtacarConHabilidades()
    {
        int valorAtaque = elfo.AtacarConHabilidades(Habilidades.Agi);
        Assert.That(valorAtaque, Is.EqualTo(60));
        Assert.That(elfo.Mana, Is.EqualTo(70));
    }

    [Test]
    public void TestAtacarConHabilidadesSinMana()
    {
        elfo.Mana = 20;
        int valorAtaque = elfo.AtacarConHabilidades(Habilidades.Agi);
        Assert.That(valorAtaque, Is.EqualTo(20));
        Assert.That(elfo.Mana, Is.EqualTo(20));
    }

    [Test]
    public void TestRecibirAtaque()
    {
        elfo.Defender(40, "Bokoblin");
        Assert.That(elfo.Vida, Is.EqualTo(160));
    }
}
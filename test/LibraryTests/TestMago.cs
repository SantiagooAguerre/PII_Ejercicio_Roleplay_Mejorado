using NUnit.Framework;

namespace roleplay;

public class TestMago
{
    private Mago mago;
    private IItemMagico itemMagico;
    private Habilidades habilidad;

    [SetUp]
    public void Setup()
    {
        mago = new Mago("HeroeDelTiempo");
        itemMagico = new Item();
        habilidad = new Habilidades { Nombre = "Agi", Ataque = 20, Costo = 30 };
    }

    [Test]
    public void TestInicializacionMago()
    {
        Assert.That(mago.Nombre, Is.EqualTo("HeroeDelTiempo"));
        Assert.That(mago.Vida, Is.EqualTo(100));
        Assert.That(mago.Ataque, Is.EqualTo(30));
        Assert.That(mago.Mana, Is.EqualTo(150));
    }

    [Test]
    public void TestAgregarHabilidad()
    {
        mago.AgregarHabilidad(habilidad);
        Assert.That(mago.Habilidades.Count, Is.EqualTo(1));
        Assert.That(mago.Habilidades[0].Nombre, Is.EqualTo("Agi"));
    }

    [Test]
    public void TestAgregarItemMagico()
    {
        mago.AgregarItemMagico(itemMagico);
        Assert.That(mago.ItemMagico.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestAtacarConHabilidades()
    {
        mago.AgregarHabilidad(habilidad);
        int valorAtaque = mago.AtacarConHabilidades(habilidad);
        Assert.That(valorAtaque, Is.EqualTo(50));
        Assert.That(mago.Mana, Is.EqualTo(120));
    }

    [Test]
    public void TestAtacarConHabilidadesSinMana()
    {
        habilidad.Costo = 200;
        mago.AgregarHabilidad(habilidad);
        int valorAtaque = mago.AtacarConHabilidades(habilidad);
        Assert.That(valorAtaque, Is.EqualTo(30));
        Assert.That(mago.Mana, Is.EqualTo(150));
    }

    [Test]
    public void TestEstudioConManaSuficiente()
    {
        mago.Estudio(50);
        Assert.That(mago.Mana, Is.EqualTo(200));
    }

    [Test]
    public void TestEstudioConManaExcediendoManaInicial()
    {
        mago.Estudio(200);
        Assert.That(mago.Mana, Is.EqualTo(150));
    }

    [Test]
    public void TestRecargaMana()
    {
        var resultado = mago.RecargaMana(30);
        Assert.That(resultado, Is.EqualTo("Aumentaste el mana en 30 puntos"));
        Assert.That(mago.Mana, Is.EqualTo(180));
    }

    [Test]
    public void TestRecargaManaAlMaximo()
    {
        mago.Mana = 120;
        var resultado = mago.RecargaMana(50);
        Assert.That(resultado, Is.EqualTo("El maná está al maximo"));
        Assert.That(mago.Mana, Is.EqualTo(150));
    }
}


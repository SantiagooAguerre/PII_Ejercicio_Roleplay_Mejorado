using NUnit.Framework;

namespace roleplay;

public class TestMago
{
    private Mago mago;
    private IItemDefensa tunicaZora;
    private IItemAtaque espadaBiggoron;
    private IItemMagico espadaMagico;
    private Habilidades ziodyne;
    private Habilidades agi;

    [SetUp]
    public void Setup()
    {
        mago = new Mago("Zelda");
        tunicaZora = Item.TunicaZora;
        espadaBiggoron = Item.EspadaBiggoron;
        ziodyne = new Habilidades { Nombre = "Ziodyne", Ataque = 50, Costo = 40 }; // Asumiendo propiedades de Habilidades
        agi = new Habilidades { Nombre = "Agi", Ataque = 30, Costo = 20 }; // Asumiendo propiedades de Habilidades
    }

    [Test]
    public void TestInicializacionMago()
    {
        Assert.That(mago.Nombre, Is.EqualTo("Zelda"));
        Assert.That(mago.Vida, Is.EqualTo(100));
        Assert.That(mago.Mana, Is.EqualTo(150));
        Assert.That(mago.Ataque, Is.EqualTo(30));
    }

    [Test]
    public void TestAgregarHabilidad()
    {
        mago.AgregarHabilidad(ziodyne);
        mago.AgregarHabilidad(agi);
        Assert.That(mago.Habilidades.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestAgregarItemMagico()
    {
        mago.AgregarItemMagico(espadaMagico); // Cambiado a AgregarItemMagico
        Assert.That(mago.ItemMagico.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestAtacarConHabilidad()
    {
        mago.AgregarHabilidad(agi);
        int valorAtaque = mago.AtacarConHabilidades(agi);
        Assert.That(valorAtaque, Is.EqualTo(30 + agi.Ataque));
        Assert.That(mago.Mana, Is.EqualTo(130)); // Verifica el maná después de usar la habilidad
    }

    [Test]
    public void TestAtacarConHabilidadSinMana()
    {
        mago.Mana = 10; // Establecer mana bajo
        int valorAtaque = mago.AtacarConHabilidades(agi);
        Assert.That(valorAtaque, Is.EqualTo(30)); // Solo ataque base
        Assert.That(mago.Mana, Is.EqualTo(10)); // Mana no cambia
    }

    [Test]
    public void TestRecargaMana()
    {
        mago.AtacarConHabilidades(ziodyne);
        mago.AtacarConHabilidades(ziodyne);
        var resultado = mago.RecargaMana(50);
        Assert.That(resultado, Is.EqualTo("Aumentaste el mana en 50 puntos"));
        Assert.That(mago.Mana, Is.EqualTo(160)); // Verifica el mana después de recargar

        mago.RecargaMana(100); // Intentar cargar más de lo máximo
        Assert.That(mago.Mana, Is.EqualTo(mago.ManaInicial)); // Mana no supera el máximo
    }

    [Test]
    public void TestEstudio()
    {
        mago.Estudio(20);
        Assert.That(mago.Mana, Is.EqualTo(170)); // Verifica mana después de estudiar

        mago.Estudio(200);
        Assert.That(mago.Mana, Is.EqualTo(170)); // Mana no cambia
    }
}
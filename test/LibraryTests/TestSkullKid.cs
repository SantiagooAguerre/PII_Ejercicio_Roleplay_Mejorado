using NUnit.Framework;
using System;
using System.IO;

namespace roleplay;

public class TestSkullKid
{
    private SkullKid skullKid;
    private Random random;

    [SetUp]
    public void Setup()
    {
        skullKid = new SkullKid("Skull Kid");
        random = new Random();
    }

    [Test]
    public void TestInicializacionSkullKid()
    {
        Assert.That(skullKid.Nombre, Is.EqualTo("Skull Kid"));
        Assert.That(skullKid.Vida, Is.EqualTo(50));
        Assert.That(skullKid.Vidabase, Is.EqualTo(50));
        Assert.That(skullKid.Ataque, Is.EqualTo(20));
    }

    [Test]
    public void TestRecibirAtaqueFisicoEsquivar()
    {
        // Forzar el resultado de Random para asegurar que el ataque sea esquivado
        var originalRandom = typeof(Random).GetField("m_Seed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        originalRandom.SetValue(random, 1); // Establecer una semilla fija

        var output = CaptureConsoleOutput(() => skullKid.RecibirAtaqueFisico(30, "Link"));
        Assert.That(output, Is.EqualTo("Skull Kid esquivó el ataque de Link.\n"));
        Assert.That(skullKid.Vida, Is.EqualTo(50)); // La vida no debe cambiar
    }

    [Test]
    public void TestRecibirAtaqueFisicoNoEsquivar()
    {
        // Forzar el resultado de Random para asegurar que el ataque no sea esquivado
        var originalRandom = typeof(Random).GetField("m_Seed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        originalRandom.SetValue(random, 2); // Establecer otra semilla

        skullKid.RecibirAtaqueFisico(30, "Link");
        Assert.That(skullKid.Vida, Is.EqualTo(20)); // La vida debe disminuir
    }

    [Test]
    public void TestRecibirAtaqueMagicoEsquivar()
    {
        // Forzar el resultado de Random para asegurar que el ataque sea esquivado
        var originalRandom = typeof(Random).GetField("m_Seed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        originalRandom.SetValue(random, 1); // Establecer una semilla fija

        var output = CaptureConsoleOutput(() => skullKid.RecibirAtaqueMagico(30, "Zelda"));
        Assert.That(output, Is.EqualTo("Skull Kid esquivó el ataque de Zelda.\n"));
        Assert.That(skullKid.Vida, Is.EqualTo(50)); // La vida no debe cambiar
    }

    [Test]
    public void TestRecibirAtaqueMagicoNoEsquivar()
    {
        // Forzar el resultado de Random para asegurar que el ataque no sea esquivado
        var originalRandom = typeof(Random).GetField("m_Seed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        originalRandom.SetValue(random, 2); // Establecer otra semilla

        skullKid.RecibirAtaqueMagico(30, "Zelda");
        Assert.That(skullKid.Vida, Is.EqualTo(20)); // La vida debe disminuir
    }

    private string CaptureConsoleOutput(Action action)
    {
        var sw = new StringWriter();
        Console.SetOut(sw);
        action();
        return sw.ToString();
    }
}
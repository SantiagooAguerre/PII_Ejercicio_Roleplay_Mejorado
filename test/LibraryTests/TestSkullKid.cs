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
        var originalRandom = typeof(Random).GetField("m_Seed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        originalRandom.SetValue(random, 1);

        var output = CaptureConsoleOutput(() => skullKid.RecibirAtaqueFisico(30, "Link"));
        Assert.That(output, Is.EqualTo("Skull Kid esquivó el ataque de Link.\n"));
        Assert.That(skullKid.Vida, Is.EqualTo(50));
    }

    [Test]
    public void TestRecibirAtaqueFisicoNoEsquivar()
    {
        var originalRandom = typeof(Random).GetField("m_Seed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        originalRandom.SetValue(random, 2);

        skullKid.RecibirAtaqueFisico(30, "Link");
        Assert.That(skullKid.Vida, Is.EqualTo(20));
    }

    [Test]
    public void TestRecibirAtaqueMagicoEsquivar()
    {
        var originalRandom = typeof(Random).GetField("m_Seed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        originalRandom.SetValue(random, 1);

        var output = CaptureConsoleOutput(() => skullKid.RecibirAtaqueMagico(30, "Zelda"));
        Assert.That(output, Is.EqualTo("Skull Kid esquivó el ataque de Zelda.\n"));
        Assert.That(skullKid.Vida, Is.EqualTo(50));
    }

    [Test]
    public void TestRecibirAtaqueMagicoNoEsquivar()
    {
        var originalRandom = typeof(Random).GetField("m_Seed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        originalRandom.SetValue(random, 2);

        skullKid.RecibirAtaqueMagico(30, "Zelda");
        Assert.That(skullKid.Vida, Is.EqualTo(20));
    }

    private string CaptureConsoleOutput(Action action)
    {
        var sw = new StringWriter();
        Console.SetOut(sw);
        action();
        return sw.ToString();
    }
}
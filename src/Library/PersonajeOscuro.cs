namespace roleplay;

using System;

public class PersonajeOscuro : IPersonajeOscuro
{
    public string Nombre { get; set; }
    public int Vida { get; set; }
    private bool Vida0 { get; set; }
    public int Ataque { get; set; }
    public int Vidabase { get; set; }
    public int VP { get; set; }
    public List<IItemAtaque> ItemAtaque { get; set; } = new List<IItemAtaque>();
    public List<IItemDefensa> ItemDefensa { get; set; } = new List<IItemDefensa>();

    public int VidaBase()
    {
        return Vidabase;
    }

    public int VidaActual()
    {
        return Vida;
    }

    public void VerificarSiEstaMuerto()
    {
        if (Vida <= 0)
        {
            Vida0 = true;
        }
    }

    public bool RevisarMuerto()
    {
        return Vida0;
    }

    public int RevisarAtaque()
    {
        return Ataque;
    }
    
    public void AgregarItemAtaque(IItemAtaque itemAtaque)
    {
        ItemAtaque.Add(itemAtaque);
    }

    public void AgregarItemDefensa(IItemDefensa itemDefensa)
    {
        ItemDefensa.Add(itemDefensa);
    }

    public int AtacarConItems(IItemAtaque itemAtaque)
    {
        int valor = Ataque;
        if (ItemAtaque.Contains(itemAtaque))
        {
            valor += itemAtaque.Ataque;
        }

        return valor;
    }

    public void Defender(int ataque, string rival)
    {
        foreach (IItemDefensa item in ItemDefensa)
        {
            Vida += item.Defensa;
        }

        Vida -= ataque;
        Console.WriteLine($"{Nombre} fue atacado por {rival}, su vida disminuyó hasta {Vida}");
    }
}
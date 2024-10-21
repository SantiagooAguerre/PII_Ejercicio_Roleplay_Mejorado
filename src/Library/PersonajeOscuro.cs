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

    
    public bool RevisarMuerto()
    {
        if (Vida <= 0)
        {
            Vida0 = true;
        }
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
        int defensaTotal = 0;
        foreach (IItemDefensa item in ItemDefensa)
        {
            defensaTotal += item.Defensa;
        }
        int dañoRecibido = ataque - defensaTotal;
        if (dañoRecibido < 0)
        {
            dañoRecibido = 0;
        }
        Vida -= dañoRecibido;
    
        Console.WriteLine($"{Nombre} fue atacado por {rival}, su vida disminuyó hasta {Vida}");
        if (Vida <= 0)
        {
            Console.WriteLine($"{Nombre} ha muerto");
        }
    }
}
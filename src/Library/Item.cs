namespace roleplay;

public class Item : IItemAtaque, IItemDefensa, IItemMagico
{
    public string Nombre { get; set; }
    public int Defensa { get; set; }
    public int Ataque { get; set; }
    
    public int RevisarElAtaque()
    {
        return Ataque;
    }
    
    public int RevisarLaDefensa()
    {
        return Defensa;
    }
    
    public void BoostHabilidadesEnemigos(ISeresMagicos villano)
    {
        villano.BoostHabilidades(Ataque);
        Console.WriteLine($"Las habilidades de {villano.Nombre} han aumentado {Ataque} de ataque");
    }
    
    public void BoostHabilidades(ISeresMagicos heroe)
    {
        heroe.BoostHabilidades(Ataque);
        Console.WriteLine($"Las habilidades de {heroe.Nombre} han aumentado {Ataque} de ataque");
        
    }
    
    public static IItemAtaque MasterSword { get; } = new Item { Nombre = "Master Sword", Ataque = 40 };
    public static IItemDefensa EscudoHyliano { get; } = new Item { Nombre = "Escudo Hyliano", Defensa = 60 };
    public static IItemAtaque EspadaBiggoron { get; } = new Item { Nombre = "Espada Biggoron", Ataque = 50 };
    public static IItemDefensa BotasDeHierro { get; } = new Item { Nombre = "Botas de Hierro", Defensa = 30 };
    public static IItemMagico Infilitracion { get; } = new Item { Nombre = "Infilitracion", Ataque = 50 };
    public static IItemDefensa TunicaZora { get; } = new Item { Nombre = "Túnica Zora", Defensa = 20 };
}
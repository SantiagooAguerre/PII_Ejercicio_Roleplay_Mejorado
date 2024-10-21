namespace roleplay;

public class Bokoblin : PersonajeOscuro
{
    public Bokoblin(string nombre)
    {
        Nombre = nombre;
        Vida = 200;
        Vidabase = 200;
        Ataque = 20;
        Vidabase = 200;
    }

    public void RecibirAtaqueFisico(int ataque, string atacante)
    {
        Console.WriteLine($"{Nombre} es inmune a los ataques físicos. El ataque de {atacante} no tuvo efecto.");
    }

    public void RecibirAtaqueMagico(int ataque, string atacante)
    {
        Console.WriteLine($"{Nombre} fue atacado mágicamente por {atacante} con {ataque} de ataque.");
        Vida -= ataque;
        RevisarMuerto();
    }
}
namespace roleplay;

public class Lizalfos : PersonajeOscuro
{
    public Lizalfos(string nombre)
    {
        Nombre = nombre;
        Vida = 200;
        Vidabase = 200;
        Ataque = 20;
        VP = 20;
    }
    
    public void RecibirAtaqueFisico(int ataque, string atacante)
    {
        Console.WriteLine($"{Nombre} fue atacado físicamente por {atacante} con {ataque} de ataque.");
        Vida -= ataque;
        RevisarMuerto();
    }

    public void RecibirAtaqueMagico(int ataque, string atacante)
    {
        Console.WriteLine($"{Nombre} es inmune a los ataques magicos. El ataque de {atacante} no tuvo efecto.");
    }
}
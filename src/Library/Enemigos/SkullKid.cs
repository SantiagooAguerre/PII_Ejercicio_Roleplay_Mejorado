namespace roleplay;

public class SkullKid : PersonajeOscuro
{
    private Random random = new Random();
    public SkullKid(string nombre)
    {
        Nombre = nombre;
        Vida = 50;
        Vidabase = 50;
        Ataque = 20;
    }
    
    public void RecibirAtaqueFisico(int ataque, string rival)
    {
        if (random.Next(100) < 50)
        {
            Console.WriteLine($"{Nombre} esquivó el ataque de {rival}.");
            return;
        }
        Vida -= ataque;
        Console.WriteLine($"{Nombre} fue atacado por {rival}, su vida disminuyó hasta {Vida}");
    }

    public void RecibirAtaqueMagico(int ataque, string rival)
    {
        if (random.Next(100) < 50)
        {
            Console.WriteLine($"{Nombre} esquivó el ataque de {rival}.");
            return;
        }
        Vida -= ataque;
        Console.WriteLine($"{Nombre} fue atacado por {rival}, su vida disminuyó hasta {Vida}");
    }
}
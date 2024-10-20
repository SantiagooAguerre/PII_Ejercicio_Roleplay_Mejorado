namespace roleplay;

public class Heroes : Personaje
{
    public void ImprimirVP()
    {
        Console.WriteLine($"Nuestro heroe recibió {this.VP} Victory Points");
    }
}
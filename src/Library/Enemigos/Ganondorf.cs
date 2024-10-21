namespace roleplay;

public class Ganondorf : PersonajeOscuro
{
    private bool Forma_Final;
    public Ganondorf(string nombre, bool formaFinal)
    {
        Nombre = nombre;
        Vidabase = 200;
        Vida = 200;
        Ataque = 20;
        Forma_Final = formaFinal;
        VP = 20;
        if (formaFinal)
        {
            Nombre += " -Forma Final-";
            Vidabase += 30;
            Vida += 30;
            Ataque += 50;
        }
    }
}
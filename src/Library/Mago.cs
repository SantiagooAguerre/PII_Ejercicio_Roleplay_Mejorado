namespace roleplay;

public class Mago : Personaje, IUniversitario
{
    public int Mana { get; set; }
    public int ManaInicial;
    public List<IItemMagico> ItemMagico { get; set; }
    public List<Habilidades> Habilidades { get; set; } = new List<Habilidades>();

    public Mago(string nombre)
    {
        Nombre = nombre;
        Vida = 100;
        Ataque = 30;
        Mana = 150;
        ManaInicial = 150;
    }

    public void AgregarHabilidad(Habilidades habilidades)
    {
        Habilidades.Add(habilidades);
    }

    public void AgregarItemMagico(IItemMagico itemMagico)
    {
        ItemMagico.Add(itemMagico);
    }

    public int AtacarConHabilidades(Habilidades habilidades = null)
    {
        int valor = Ataque;

        if (habilidades != null)
        {
            if (Mana >= habilidades.Costo)
            {
                Mana -= habilidades.Costo;
                valor += habilidades.Ataque;
            }
            else
            {
                Console.WriteLine($"Magia insuficiente");
            }
        }
        return valor;
    }

    public void Estudio(int boost)
    {
        ManaInicial += boost;
    }

    public string RecargaMana(int mana)
    {
            
        if ((Mana + mana) >= ManaInicial)
        {
            Mana = ManaInicial;
            return ("El maná está al maximo");
        }
        else
        {
            Mana += mana;
            return ($"Aumentaste el mana en {mana} puntos");
        }
    }
}
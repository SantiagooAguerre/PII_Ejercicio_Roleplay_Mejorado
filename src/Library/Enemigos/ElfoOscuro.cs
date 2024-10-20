namespace roleplay;

public class ElfoOscuro : Enemigos, ISanador
{
    public int Mana { get; set; }
    public int ManaInicial;
    private List<Habilidades> Habilidades = new List<Habilidades>();
    private List<IItemMagico> ItemMagico = new List<IItemMagico>();
    
    public int CantidadHabilidades
    {
        get { return Habilidades.Count; }
    }

    public List<Habilidades> Hechizos
    {
        get { return Habilidades; }
    }

    public ElfoOscuro(string nombre)
    {
        Nombre = nombre;
        Vida = 200;
        Ataque = 20;
        Vidabase = 200;
        Mana = 100;
        ManaInicial = 100;
    }

    public void AgregarHabilidad(Habilidades habilidades)
    {
        Habilidades.Add(habilidades);
    }
    
    public void AgregarItemMagico(IItemMagico itemMagico)
    {
        ItemMagico.Add(itemMagico);
    }

    public void MostrarHabilidades()
    {
        for (int i = 0; i < Habilidades.Count; i++)
        {
            Console.WriteLine($"{i+1} - {Habilidades[i].Nombre} / {Habilidades[i].Ataque}");
        }
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

    public void BoostHabilidades(int ataque)
    {
        foreach (var habilidad in Habilidades)
        {
            habilidad.Ataque += ataque;
        }
    }

    public string RecargaMana(int mana)
    {
        if (mana > ManaInicial)
        {
            return ("El maná está al maximo");
        }
        else
        {
            Mana += mana;
            return ($"Aumentaste el mana en {mana} puntos");
        }
    }
    
    public int ValorAtaqueHechizos(Habilidades habilidad = null)
    {
        int valor = Ataque;
        foreach (var itemagico in ItemMagico)
        {
            itemagico.BoostHabilidades(this);
        }
        if (habilidad != null)
        {
            if (Mana >= habilidad.Costo)
            {
                Mana -= habilidad.Costo;
                valor += habilidad.Ataque;
            }
            else
            {
                Console.WriteLine($"No se puede cargar la habilidad {Nombre} de {habilidad.Nombre} por falta de maná");
            }
        }
                
        return valor;
    }

    public void Curacion(int curar, IPersonaje personajequecurar)
    {
        if (personajequecurar.VidaActual() + curar > personajequecurar.VidaBase() || curar > 20)
        {
            Console.WriteLine(
                $"{Nombre} no ha podido curarse");
        }
        else
        {
            Vida += curar;
            Console.WriteLine($"{Nombre} recuperó PS, su vida llegó hasta {Vida}");
        }
    }
}
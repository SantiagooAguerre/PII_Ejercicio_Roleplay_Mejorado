namespace roleplay;

public class Elfo : Heroes, ISanador
{
    public int Mana { get; set; }
    public int ManaInicial;
    private List<Habilidades> Habilidades = new List<Habilidades>();
    private List<IItemMagico> ItemMagico = new List<IItemMagico>();
    
    public int CantidadHabilidades
    {
        get { return Habilidades.Count; }
    }

    public List<Habilidades> Conjuros
    {
        get { return Habilidades; }
    }

    public Elfo(string nombre)
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

    public void Curacion(int curar, IPersonajeBueno personajequecurar)
    {
        if ((personajequecurar.VidaActual() + curar) > personajequecurar.VidaBase() || curar > 20)
        {
            Console.WriteLine($"{Nombre} intentó curar a {personajequecurar.Nombre}, pero no puede curar más de su vida base o mas de 20 puntos de vida por turno.");
        }
        else
        {
            personajequecurar.CurarVida(personajequecurar.VidaActual() + curar);
            Console.WriteLine($"{Nombre} curó a {personajequecurar.Nombre} {curar} PS, su vida actual es {personajequecurar.VidaActual()}-{personajequecurar.VidaBase()}.");
        }
    }

}
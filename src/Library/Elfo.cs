using System.Collections;

namespace roleplay;

public class Elfo : Personaje, ISanador
{
    public int Mana { get; set; }
    public int VidaBase;
    public int ManaInicial;
    public List<Habilidades> Habilidades { get; set; } = new List<Habilidades>();
    public List<IItemMagico> ItemMagico { get; set; }

    public Elfo(string nombre)
    {
        Nombre = nombre;
        Vida = 200;
        Ataque = 20;
        VidaBase = 200;
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

    public void Curacion(int curar)
    {
        if ((Vida + curar) > VidaBase || curar > 20)
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
using System.Collections;

namespace roleplay
{
    public class Elfo : IPersonaje, IElfo, ISeresMagicos
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Mana { get; set; }
        public int VidaBase;
        public int ManaInicial;
        public List<Habilidades> Habilidades { get; set; } = new List<Habilidades>();
        public List<IItemAtaque> ItemAtaque { get; set; } = new List<IItemAtaque>();
        public List<IItemDefensa> ItemDefensa { get; set; } = new List<IItemDefensa>();

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

        public void AgregarItemAtaque(IItemAtaque itemAtaque)
        {
            ItemAtaque.Add(itemAtaque);
        }
        
        public void AgregarItemDefensa(IItemDefensa itemDefensa)
        {
            ItemDefensa.Add(itemDefensa);
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
        
        public int AtacarConItems(IItemAtaque itemAtaque)
        {
            int valor = Ataque;
            if (ItemAtaque.Contains(itemAtaque))
            {
                valor += itemAtaque.Ataque;
            } 
            return valor;
        }

        public void Defender(int ataque, string rival)
        {
            
            foreach (IItemDefensa item in ItemDefensa)
            {
                Vida += item.Defensa;
            }

            Vida -= ataque;
            Console.WriteLine($"{Nombre} fue atacado por {rival}, su vida disminuyó hasta {Vida}");
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
}
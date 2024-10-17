
using System.Collections;

namespace roleplay
{
    public class Enano : IPersonaje
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public List<IItemAtaque> ItemAtaque { get; set; } = new List<IItemAtaque>();
        public List<IItemDefensa> ItemDefensa { get; set; } = new List<IItemDefensa>();

        public Enano(string nombre)
        {
            Nombre = nombre;
            Vida = 250;
            Ataque = 50;
        }

        public void AgregarItemAtaque(IItemAtaque itemAtaque)
        {
            ItemAtaque.Add(itemAtaque);
        }

        public void AgregarItemDefensa(IItemDefensa itemDefensa)
        {
            ItemDefensa.Add(itemDefensa);
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
            Console.WriteLine($"{Nombre} fue atacado por {rival}, su vida disminuyyó hasta {Vida}");
        }
    }
}
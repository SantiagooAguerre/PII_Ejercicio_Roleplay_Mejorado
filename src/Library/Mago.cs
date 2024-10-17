using System.Collections;

namespace roleplay
{
    public class Mago : IPersonaje, ISeresMagicos
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Mana { get; set; }
        public int Ataque { get; set; }
        public int ManaInicial;
        public List<Habilidades> Habilidades { get; set; } = new List<Habilidades>();
        public List<IItemAtaque> ItemAtaque { get; set; } = new List<IItemAtaque>();
        public List<IItemDefensa> ItemDefensa { get; set; } = new List<IItemDefensa>();

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
            Console.WriteLine($"{Nombre} fue atacado por {rival}, su vida disminuyyó hasta {Vida}");
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
}

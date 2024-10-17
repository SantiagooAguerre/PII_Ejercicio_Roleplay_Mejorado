namespace roleplay;
using System.Collections;

public interface IPersonaje
{
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }
    public List<IItemAtaque> ItemAtaque { get; set; }
    public List<IItemDefensa> ItemDefensa { get; set; }
    public void Defender(int ataque, string rival);
    public int AtacarConItems(IItemAtaque itemAtaque);
    public void AgregarItemAtaque(IItemAtaque itemAtaque);
    public void AgregarItemDefensa(IItemDefensa itemDefensa);
}
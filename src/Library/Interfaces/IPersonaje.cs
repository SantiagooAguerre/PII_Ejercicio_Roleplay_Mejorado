namespace roleplay;

public interface IPersonaje
{
    string Nombre { get; set; }
    static int Vida;
    static int Vidabase;
    static int Ataque;
    static int VP;
    public int VidaBase();
    public int VidaActual();
    public List<IItemAtaque> ItemAtaque { get; set; }
    public List<IItemDefensa> ItemDefensa { get; set; }
    public void Defender(int ataque, string rival);
    public int AtacarConItems(IItemAtaque itemAtaque);
    public void AgregarItemAtaque(IItemAtaque itemAtaque);
    public void AgregarItemDefensa(IItemDefensa itemDefensa);
}
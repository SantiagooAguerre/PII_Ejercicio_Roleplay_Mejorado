namespace roleplay;

public interface IPersonajeBueno
{
    string Nombre { get; set; }
    int Vida { get; set; }
    static int Vidabase;
    static int Ataque;
    static int VP;
    public int VidaBase();
    public int VidaActual();
    
    public bool RevisarMuerto();
    public void RecibirVP(int VictoryPoints);
    public void CurarVida(int curacion);
    public List<IItemAtaque> ItemAtaque { get; set; }
    public List<IItemDefensa> ItemDefensa { get; set; }
    public void Defender(int ataque, string rival);
    public int AtacarConItems(IItemAtaque itemAtaque);
    public void AgregarItemAtaque(IItemAtaque itemAtaque);
    public void AgregarItemDefensa(IItemDefensa itemDefensa);
}
namespace roleplay;

public interface ISeresMagicos : IPersonaje
{
    public int Mana { get; set; }
    public List<Habilidades> Habilidades { get; set; }
    public void AgregarHabilidad(Habilidades habilidades);
    public int AtacarConHabilidades(Habilidades habilidades = null);
    public string RecargaMana(int mana);
    public void AgregarItemMagico(IItemMagico itemMagico);
}
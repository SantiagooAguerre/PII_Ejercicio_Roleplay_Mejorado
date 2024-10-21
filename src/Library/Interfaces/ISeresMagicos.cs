namespace roleplay;

public interface ISeresMagicos : IPersonajeBueno
{
    string Nombre { get; set; }
    int Mana { get; set; }
    void AgregarHabilidad(Habilidades habilidades);
    int AtacarConHabilidades(Habilidades habilidades);
    public void MostrarHabilidades();
    void BoostHabilidades(int ataque);
    void AgregarItemMagico(IItemMagico itemMagico);
    
}
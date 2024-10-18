namespace roleplay;

public interface ISeresMagicos : IPersonaje
{
    string Nombre { get; set; }
    int Mana { get; set; }
    void AgregarHabilidad(Habilidades habilidades);
    int AtacarConHabilidades(Habilidades habilidades = null);
    void BoostHabilidades(int ataque);
    void AgregarItemMagico(IItemMagico itemMagico);
}
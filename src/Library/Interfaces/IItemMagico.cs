namespace roleplay;

public interface IItemMagico
{
    string Nombre { get; set; }
    int Ataque { get; set; }
    public void BoostHabilidades(ISeresMagicos heroe);
}
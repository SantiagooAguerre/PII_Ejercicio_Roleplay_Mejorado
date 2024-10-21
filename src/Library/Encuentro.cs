namespace roleplay;

public abstract class Encuentro
{
    public List<IPersonajeBueno> Heroes { get; set; }
    public List<IPersonajeOscuro> Enemigos { get; set; }

    public Encuentro(List<IPersonajeBueno> heroes, List<IPersonajeOscuro> enemigos)
    {
        this.Heroes = heroes;
        this.Enemigos = enemigos;
    }

    public abstract void DoEncounter();
}
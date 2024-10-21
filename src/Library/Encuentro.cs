namespace roleplay;

public abstract class Encuentro
{
    public List<PersonajeBueno> Heroes { get; set; }
    public List<PersonajeOscuro> Enemigos { get; set; }

    public Encuentro(List<PersonajeBueno> heroes, List<PersonajeOscuro> enemigos)
    {
        this.Heroes = heroes;
        this.Enemigos = enemigos;
    }

    public abstract void DoEncounter();
}
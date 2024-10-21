namespace roleplay;

public class EncuentroCombate:Encuentro
{
    public EncuentroCombate(List<PersonajeBueno> heroes, List<PersonajeOscuro> enemigos):base(heroes,enemigos)
    {
    }

    public override void DoEncounter()
    {
        while (CheckHeroesVivos() && CheckEnemigosVivos())
        {
            AtacanEnemigos();
            AtacanHeroes();
        }
        if (CheckHeroesVivos())
        {
            Console.WriteLine("¡Los héroes han ganado el encuentro!");
        }
        else if (CheckEnemigosVivos())
        {
            Console.WriteLine("¡Los enemigos han ganado el encuentro!");
        }
    }

    private bool CheckHeroesVivos()
    {
        foreach (PersonajeBueno Bueno in Heroes)
        {
            if (!Bueno.RevisarMuerto())
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckEnemigosVivos()
    {
        foreach (PersonajeOscuro Oscuro in Enemigos)
        {
            if (!Oscuro.RevisarMuerto())
            {
                return true;
            }
        }

        return false;
    }
    
    private void AtacanEnemigos()
    {
        int numHeroes = Heroes.Count(h => h.Vida > 0);
        int heroIndex = 0;

        foreach (var enemigo in Enemigos.Where(e => e.Vida > 0))
        {
            var heroe = Heroes[heroIndex % numHeroes];
            heroe.Defender(enemigo.Ataque, enemigo.Nombre); 
            heroIndex++;
        }
    }

    private void AtacanHeroes()
    {
        foreach (var heroe in Heroes.Where(h => h.Vida > 0))
        {
            foreach (var enemigo in Enemigos.Where(e => e.Vida > 0))
            {
                enemigo.Defender(heroe.Ataque, heroe.Nombre);

                // Si el enemigo murió tras el ataque, el héroe gana sus puntos de victoria (VP)
                if (enemigo.Vida <= 0)
                {
                    heroe.VP += enemigo.VP;
                    Console.WriteLine($"{heroe.Nombre} derrotó a {enemigo.Nombre} y ganó {enemigo.VP} puntos de victoria.");

                    // Curar al héroe si ha acumulado 5 o más VP
                    if (heroe.VP >= 5)
                    {
                        heroe.CurarVida(25);
                    }
                }
            }
        }
    }
}
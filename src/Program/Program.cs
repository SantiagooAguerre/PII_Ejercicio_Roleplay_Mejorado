namespace roleplay;

class Program
{
    static void Main(string[] args)
    {
        ISanador elfo = new Elfo("Link");
        IPersonajeBueno enano = new Enano("Darunia");
        IUniversitario mago = new Mago("Zelda");

        Bokoblin bokoblin = new Bokoblin("Bokoblin");
        Lizalfos lizalfos = new Lizalfos("Lizalfo");
        SkullKid skullkid = new SkullKid("SkullKid");
        IPersonajeOscuro ganondorf = new Ganondorf("Ganondorf", false);
        
        IItemAtaque espada = Item.MasterSword;
        IItemAtaque espadagrande = Item.EspadaBiggoron;
        IItemDefensa escudo = Item.EscudoHyliano;
        IItemDefensa botas = Item.BotasDeHierro;
        IItemDefensa tunica = Item.TunicaZora;

        elfo.AgregarItemAtaque(espada);
        elfo.AgregarItemDefensa(escudo);

        enano.AgregarItemDefensa(botas);
        enano.AgregarItemDefensa(tunica);

        mago.AgregarItemDefensa(tunica);
            
        mago.Estudio(20);

        List<IPersonajeBueno> heroesList = new List<IPersonajeBueno> { enano };
        List<IPersonajeOscuro> enemigosList = new List<IPersonajeOscuro> { bokoblin, lizalfos, skullkid, ganondorf };

        EncuentroCombate encuentro = new EncuentroCombate(heroesList, enemigosList);
        encuentro.DoEncounter();
    }
}

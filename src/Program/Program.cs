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

        int ataqueElfo = elfo.AtacarConItems(espada);
        ganondorf.Defender(ataqueElfo, elfo.Nombre);
            
        int ataqueEnano = enano.AtacarConItems(espadagrande);
        skullkid.RecibirAtaqueFisico(ataqueEnano, enano.Nombre);
        mago.Defender(ataqueEnano, enano.Nombre);

        Habilidades habilidades = Habilidades.Ziodyne;
            
        int ataqueMago = mago.AtacarConHabilidades(habilidades: habilidades);
            
        elfo.Defender(ataqueMago, mago.Nombre);
            
        elfo.Curacion(5, mago);
    }
}

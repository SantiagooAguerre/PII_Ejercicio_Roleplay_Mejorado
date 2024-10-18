namespace roleplay;

class Program
{
    static void Main(string[] args)
    {
        ISanador elfo = new Elfo("Link");
        IPersonaje enano = new Enano("Darunia");
        IUniversitario mago = new Mago("Zelda");
            
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
            
        mago.AgregarHabilidad(Habilidades.Agi);
        mago.AgregarHabilidad(Habilidades.Ziodyne);
            
        mago.Estudio(20);
            
        Console.WriteLine("Ataques y habilidades:");

        int ataqueElfo = elfo.AtacarConItems(espada);
        enano.Defender(ataqueElfo, elfo.Nombre);
            
        int ataqueEnano = enano.AtacarConItems(espadagrande);
        mago.Defender(ataqueEnano, enano.Nombre);

        Habilidades habilidades = Habilidades.Ziodyne;
        int ataqueMago = 0;
            
        ataqueMago = mago.AtacarConHabilidades(habilidades: habilidades);
            
        elfo.Defender(ataqueMago, mago.Nombre);
            
        elfo.Curacion(30);
            
            
    }
}

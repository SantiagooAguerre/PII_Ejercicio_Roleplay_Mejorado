namespace roleplay
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonaje elfo = new Elfo("Link");
            IPersonaje enano = new Enano("Darunia");
            IPersonaje mago = new Mago("Zelda");
            
            Item espada = Item.MasterSword;
            Item espadagrande = Item.EspadaBiggoron;
            Item escudo = Item.EscudoHyliano;
            Item botas = Item.BotasDeHierro;
            Item tunica = Item.TunicaZora;

            elfo.AgregarItem(espada);
            elfo.AgregarItem(escudo);

            enano.AgregarItem(botas);
            enano.AgregarItem(tunica);

            mago.AgregarItem(tunica);
            if (mago is Mago EsMaguitoFiuFiu)
            {
                EsMaguitoFiuFiu.AgregarHabilidad(Habilidades.Agi);
                EsMaguitoFiuFiu.AgregarHabilidad(Habilidades.Ziodyne);
                EsMaguitoFiuFiu.Estudio(20);
            }
            
            Console.WriteLine("Ataques y habilidades:");

            int ataqueElfo = elfo.AtacarConItems(espada);
            enano.Defender(ataqueElfo, elfo.Nombre);
            
            int ataqueEnano = enano.AtacarConItems(espadagrande);
            mago.Defender(ataqueEnano, enano.Nombre);

            Habilidades habilidades = Habilidades.Ziodyne;
            int ataqueMago = 0;
            if (mago is Mago EsTremendoMaguitoFueguito)
            {
                ataqueMago = EsTremendoMaguitoFueguito.AtacarConHabilidades(habilidades: habilidades);
            }
            elfo.Defender(ataqueMago, mago.Nombre);
            if (elfo is Elfo jajaOrejasGrandes)
            {
                jajaOrejasGrandes.Curacion(30);
            }
            
        }
    }
}
    public class Ave
    {
        public string Nombre { get; set; }
        public string Habitat { get; set; }

        public Ave(string nombre, string habitat)
        {
            Nombre = nombre;
            Habitat = habitat;
        }

        public virtual void Desplazarse() => Console.WriteLine($"{Nombre} se está desplazando.");
        public virtual void Alimentarse() => Console.WriteLine($"{Nombre} está buscando alimento.");
        public virtual void Comunicarse() => Console.WriteLine($"{Nombre} está emitiendo un sonido.");
    }

    public class Halcon : Ave
    {
        public Halcon(string nombre, string habitat) : base(nombre, habitat) { }

        public override void Desplazarse() => Console.WriteLine($"{Nombre} vuela rápidamente sobre {Habitat}.");
        public override void Comunicarse() => Console.WriteLine($"{Nombre} emite un chillido agudo.");
    }

    public class Cisne : Ave
    {
        public Cisne(string nombre, string habitat) : base(nombre, habitat) { }

        public override void Alimentarse() => Console.WriteLine($"{Nombre} filtra agua en {Habitat} para comer.");
        public override void Comunicarse() => Console.WriteLine($"{Nombre} grazna suavemente.");
    }

    public class Kiwi : Ave
    {
        public Kiwi(string nombre, string habitat) : base(nombre, habitat) { }

        public override void Desplazarse() => Console.WriteLine($"{Nombre} camina por el suelo de {Habitat}.");
        public override void Comunicarse() => Console.WriteLine($"{Nombre} emite un sonido grave.");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ave halcon = new Halcon("Halcon Peregrino", "montañas");
            Ave cisne = new Cisne("Cisne Blanco", "lagos");
            Ave kiwi = new Kiwi("Kiwi Marrón", "bosques");

            Console.WriteLine("Comportamiento del Halcón:");
            halcon.Desplazarse();
            halcon.Alimentarse();
            halcon.Comunicarse();

            Console.WriteLine("\nComportamiento del Cisne:");
            cisne.Desplazarse();
            cisne.Alimentarse();
            cisne.Comunicarse();

            Console.WriteLine("\nComportamiento del Kiwi:");
            kiwi.Desplazarse();
            kiwi.Alimentarse();
            kiwi.Comunicarse();
        }
    }
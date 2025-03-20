    abstract class Autobus
    {
        public string Nombre { get; private set; }
        public int Capacidad { get; private set; }
        public int AsientosOcupados { get; private set; }
        public decimal PrecioPasaje { get; private set; }
        public decimal VentasTotales { get; private set; }

        protected Autobus(string nombre, int capacidad, decimal precioPasaje)
        {
            Nombre = nombre;
            Capacidad = capacidad;
            PrecioPasaje = precioPasaje;
            AsientosOcupados = 0;
            VentasTotales = 0;
        }

        public void VenderPasaje(int cantidad)
        {
            if (AsientosOcupados + cantidad <= Capacidad)
            {
                AsientosOcupados += cantidad;
                VentasTotales += cantidad * PrecioPasaje;
                Console.WriteLine($"{Nombre}: {cantidad} pasajeros. Ventas: {VentasTotales:C}. Quedan {Capacidad - AsientosOcupados} asientos disponibles.");
            }
            else
            {
                Console.WriteLine($"{Nombre}: No hay suficientes asientos disponibles. Solo quedan {Capacidad - AsientosOcupados} asientos.");
            }
        }
    }

    class AutobusPlatinum : Autobus
    {
        public AutobusPlatinum() : base("Autobús Platinum", 20, 5000) { }
    }

    class AutobusGold : Autobus
    {
        public AutobusGold() : base("Autobús Gold", 15, 4000) { }
    }

    class AutobusEconomico : Autobus
    {
        public AutobusEconomico() : base("Autobús Económico", 30, 2000) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Autobus platinum = new AutobusPlatinum();
            Autobus gold = new AutobusGold();
            Autobus economico = new AutobusEconomico();

            Console.WriteLine("=== Venta de pasajes ===");

            // Ejemplo 1: Venta exitosa
            platinum.VenderPasaje(5);
            gold.VenderPasaje(3);
            economico.VenderPasaje(10);

            Console.WriteLine("\n=== Intento de venta con asientos insuficientes ===");

            // Ejemplo 2: Intento de venta con asientos insuficientes
            platinum.VenderPasaje(17); // Solo quedan 15 asientos
            gold.VenderPasaje(13);    // Solo quedan 12 asientos
            economico.VenderPasaje(25); // Solo quedan 20 asientos

            Console.WriteLine("\n=== Venta adicional ===");

            // Ejemplo 3: Venta adicional después de intentos fallidos
            platinum.VenderPasaje(10);
            gold.VenderPasaje(5);
            economico.VenderPasaje(15);

            Console.WriteLine("\n=== Resumen final ===");
            Console.WriteLine($"{platinum.Nombre}: Ventas totales: {platinum.VentasTotales:C}, Asientos ocupados: {platinum.AsientosOcupados}/{platinum.Capacidad}");
            Console.WriteLine($"{gold.Nombre}: Ventas totales: {gold.VentasTotales:C}, Asientos ocupados: {gold.AsientosOcupados}/{gold.Capacidad}");
            Console.WriteLine($"{economico.Nombre}: Ventas totales: {economico.VentasTotales:C}, Asientos ocupados: {economico.AsientosOcupados}/{economico.Capacidad}");
        }
    }
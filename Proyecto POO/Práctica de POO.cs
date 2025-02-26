class Motor
{
    // Atributos privados
    private int litrosDeAceite;
    private int potencia;

    // Constructor
    public Motor(int potencia)
    {
        this.potencia = potencia;
        this.litrosDeAceite = 0;
    }

    // Getters y Setters
    public int LitrosDeAceite
    {
        get { return litrosDeAceite; }
        set { litrosDeAceite = value; }
    }

    public int Potencia
    {
        get { return potencia; }
        set { potencia = value; }
    }
}

class Coche
{
    // Atributos privados
    private Motor motor;
    private string marca;
    private string modelo;
    private double precioAverias;

    // Constructor
    public Coche(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.precioAverias = 0;
        this.motor = new Motor(100); // Potencia por defecto
    }

    // Getters
    public Motor Motor
    {
        get { return motor; }
    }

    public string Marca
    {
        get { return marca; }
    }

    public string Modelo
    {
        get { return modelo; }
    }

    public double PrecioAverias
    {
        get { return precioAverias; }
    }

    // Método para acumular averías
    public void AcumularAveria(double importe)
    {
        precioAverias += importe;
    }
}

class Garaje
{
    // Atributos privados
    private Coche? cocheEnTaller;
    private string? averiaAsociada;
    private int cochesAtendidos;

    // Constructor
    public Garaje()
    {
        cocheEnTaller = null;
        averiaAsociada = null;
        cochesAtendidos = 0;
    }

    
    public bool AceptarCoche(Coche coche, string averia)
    {
        if (cocheEnTaller != null)
        {
            return false; // No se puede aceptar otro coche si ya hay uno en el taller
        }

        cocheEnTaller = coche;
        averiaAsociada = averia;
        cochesAtendidos++;
        return true;
    }

        public Coche? DevolverCoche()
    {
        Coche? cocheDevuelto = cocheEnTaller;
        cocheEnTaller = null;
        averiaAsociada = null;
        return cocheDevuelto;
    }

    // Getter para el número de coches atendidos
    public int CochesAtendidos
    {
        get { return cochesAtendidos; }
    }
}

class PracticaPOO
{
    static void Main(string[] args)
    {
        // Crear un garaje
        Garaje garaje = new Garaje();

        // Crear 2 coches
        Coche coche1 = new Coche("Toyota", "Corolla");
        Coche coche2 = new Coche("Honda", "Civic");

        // Atender los coches en el garaje
        Random random = new Random();

        // Coche 1 entra al garaje por primera vez
        if (garaje.AceptarCoche(coche1, "aceite"))
        {
            double importeAveria = random.NextDouble() * 100;
            coche1.AcumularAveria(importeAveria);
            if (garaje.CochesAtendidos == 1)
            {
                coche1.Motor.LitrosDeAceite += 10; // Incrementar litros de aceite
            }
            garaje.DevolverCoche();
        }

        // Coche 2 entra al garaje por primera vez
        if (garaje.AceptarCoche(coche2, "frenos"))
        {
            double importeAveria = random.NextDouble() * 100;
            coche2.AcumularAveria(importeAveria);
            garaje.DevolverCoche();
        }

        // Coche 1 entra al garaje por segunda vez
        if (garaje.AceptarCoche(coche1, "motor"))
        {
            double importeAveria = random.NextDouble() * 100;
            coche1.AcumularAveria(importeAveria);
            garaje.DevolverCoche();
        }

        // Coche 2 entra al garaje por segunda vez
        if (garaje.AceptarCoche(coche2, "aceite"))
        {
            double importeAveria = random.NextDouble() * 100;
            coche2.AcumularAveria(importeAveria);
            if (garaje.CochesAtendidos == 4)
            {
                coche2.Motor.LitrosDeAceite += 10; // Incrementar litros de aceite
            }
            garaje.DevolverCoche();
        }

        // Mostrar información de los coches
        Console.WriteLine("Información del Coche 1:");
        Console.WriteLine($"Marca: {coche1.Marca}, Modelo: {coche1.Modelo}");
        Console.WriteLine($"Precio acumulado de averías: {coche1.PrecioAverias:C}");
        Console.WriteLine($"Litros de aceite: {coche1.Motor.LitrosDeAceite}");
        Console.WriteLine($"Potencia del motor: {coche1.Motor.Potencia}");

        Console.WriteLine("\nInformación del Coche 2:");
        Console.WriteLine($"Marca: {coche2.Marca}, Modelo: {coche2.Modelo}");
        Console.WriteLine($"Precio acumulado de averías: {coche2.PrecioAverias:C}");
        Console.WriteLine($"Litros de aceite: {coche2.Motor.LitrosDeAceite}");
        Console.WriteLine($"Potencia del motor: {coche2.Motor.Potencia}");
    }
}
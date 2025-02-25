class Motor
{
    private int litros_de_aceite;
    private int potencia;

    public Motor(int potencia)
    {
        this.potencia = potencia;
        this.litros_de_aceite = 0;
    }

    public int GetLitrosDeAceite()
    {
        return litros_de_aceite;
    }

    public void SetLitrosDeAceite(int litros)
    {
        this.litros_de_aceite = litros;
    }

    public int GetPotencia()
    {
        return potencia;
    }

    public void SetPotencia(int potencia)
    {
        this.potencia = potencia;
    }
}

class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double precioAverias;

    public Coche(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.precioAverias = 0;
        this.motor = new Motor(100); // Potencia por defecto
    }

    public Motor GetMotor()
    {
        return motor;
    }

    public string GetMarca()
    {
        return marca;
    }

    public string GetModelo()
    {
        return modelo;
    }

    public double GetPrecioAverias()
    {
        return precioAverias;
    }

    public void AcumularAveria(double importe)
    {
        precioAverias += importe;
    }
}

class Garaje
{
    private Coche? coche; 
    private string? averiaAsociada; 
    private int cochesAtendidos;

    public Garaje()
    {
        coche = null; 
        averiaAsociada = null;
        cochesAtendidos = 0;
    }

    public bool AceptarCoche(Coche coche, string averia)
    {
        if (this.coche != null)
        {
            return false; 
        }

        this.coche = coche;
        this.averiaAsociada = averia;
        cochesAtendidos++;
        return true;
    }

    public Coche? DevolverCoche() 
    {
        Coche? cocheDevuelto = this.coche;
        this.coche = null;
        this.averiaAsociada = null;
        return cocheDevuelto;
    }

    public int GetCochesAtendidos()
    {
        return cochesAtendidos;
    }
}
class PracticaPOO
{
    static void Main(string[] args)
    {
        Garaje garaje = new Garaje();
        Coche coche1 = new Coche("Toyota", "Corolla");
        Coche coche2 = new Coche("Honda", "Civic");

        Random random = new Random();

        // Coche 1 entra al garaje
        if (garaje.AceptarCoche(coche1, "aceite"))
        {
            double importeAveria = random.NextDouble() * 100;
            coche1.AcumularAveria(importeAveria);
            if (garaje.GetCochesAtendidos() == 1)
            {
                coche1.GetMotor().SetLitrosDeAceite(coche1.GetMotor().GetLitrosDeAceite() + 10);
            }
            garaje.DevolverCoche();
        }

        // Coche 2 entra al garaje
        if (garaje.AceptarCoche(coche2, "frenos"))
        {
            double importeAveria = random.NextDouble() * 100;
            coche2.AcumularAveria(importeAveria);
            garaje.DevolverCoche();
        }

        // Coche 1 entra al garaje por segunda vez
        if (garaje.AceptarCoche(coche1, "aceite"))
        {
            double importeAveria = random.NextDouble() * 100;
            coche1.AcumularAveria(importeAveria);
            if (garaje.GetCochesAtendidos() == 3)
            {
                coche1.GetMotor().SetLitrosDeAceite(coche1.GetMotor().GetLitrosDeAceite() + 10);
            }
            garaje.DevolverCoche();
        }

        // Coche 2 entra al garaje por segunda vez
        if (garaje.AceptarCoche(coche2, "motor"))
        {
            double importeAveria = random.NextDouble() * 100;
            coche2.AcumularAveria(importeAveria);
            garaje.DevolverCoche();
        }

        // Mostrar información de los coches
        Console.WriteLine("Información del Coche 1:");
        Console.WriteLine($"Marca: {coche1.GetMarca()}, Modelo: {coche1.GetModelo()}");
        Console.WriteLine($"Precio acumulado de averías: {coche1.GetPrecioAverias():C}");
        Console.WriteLine($"Litros de aceite: {coche1.GetMotor().GetLitrosDeAceite()}");
        Console.WriteLine($"Potencia del motor: {coche1.GetMotor().GetPotencia()}");

        Console.WriteLine("\nInformación del Coche 2:");
        Console.WriteLine($"Marca: {coche2.GetMarca()}, Modelo: {coche2.GetModelo()}");
        Console.WriteLine($"Precio acumulado de averías: {coche2.GetPrecioAverias():C}");
        Console.WriteLine($"Litros de aceite: {coche2.GetMotor().GetLitrosDeAceite()}");
        Console.WriteLine($"Potencia del motor: {coche2.GetMotor().GetPotencia()}");
    }
}
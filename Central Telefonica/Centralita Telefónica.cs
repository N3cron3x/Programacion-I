// Clase base abstracta que representa una llamada
public abstract class Llamada
{
    public string NumOrigen { get; private set; }
    public string NumDestino { get; private set; }
    public double Duracion { get; private set; }

    protected Llamada(string numOrigen, string numDestino, double duracion)
    {
        NumOrigen = numOrigen;
        NumDestino = numDestino;
        Duracion = duracion;
    }

    public abstract double CalcularPrecio();
}

// Clase que representa una llamada local
public class LlamadaLocal : Llamada
{
    private const double PrecioPorSegundo = 0.15;

    public LlamadaLocal(string numOrigen, string numDestino, double duracion)
        : base(numOrigen, numDestino, duracion) { }

    public override double CalcularPrecio()
    {
        return Duracion * PrecioPorSegundo;
    }

    public override string ToString()
    {
        return $"Llamada Local - Origen: {NumOrigen}, Destino: {NumDestino}, Duración: {Duracion}s, Coste: {CalcularPrecio():C}";
    }
}

// Clase que representa una llamada provincial
public class LlamadaProvincial : Llamada
{
    private static readonly double[] PreciosPorFranja = { 0.20, 0.25, 0.30 };
    public int Franja { get; private set; }

    public LlamadaProvincial(string numOrigen, string numDestino, double duracion, int franja)
        : base(numOrigen, numDestino, duracion)
    {
        Franja = franja;
    }

    public override double CalcularPrecio()
    {
        return Duracion * PreciosPorFranja[Franja - 1];
    }

    public override string ToString()
    {
        return $"Llamada Provincial - Origen: {NumOrigen}, Destino: {NumDestino}, Duración: {Duracion}s, Franja: {Franja}, Coste: {CalcularPrecio():C}";
    }
}

// Clase que representa la centralita telefónica
public class Centralita
{
    private int contadorLlamadas;
    private double acumuladoCostes;
    private List<Llamada> llamadas;

    public Centralita()
    {
        llamadas = new List<Llamada>();
    }

    public void RegistrarLlamada(Llamada llamada)
    {
        llamadas.Add(llamada);
        contadorLlamadas++;
        acumuladoCostes += llamada.CalcularPrecio();
        Console.WriteLine(llamada);
    }

    public void GenerarInforme()
    {
        Console.WriteLine("\nInforme de la Centralita:");
        Console.WriteLine($"Total de Llamadas: {contadorLlamadas}");
        Console.WriteLine($"Facturación Total: {acumuladoCostes:C}");
    }
}

// Clase principal con el método Main
class Practica2
{
    static void Main(string[] args)
    {
        Centralita centralita = new Centralita();

        centralita.RegistrarLlamada(new LlamadaLocal("123456789", "987654321", 120));
        centralita.RegistrarLlamada(new LlamadaProvincial("123456789", "987654321", 180, 1));
        centralita.RegistrarLlamada(new LlamadaLocal("123456789", "987654321", 60));
        centralita.RegistrarLlamada(new LlamadaProvincial("123456789", "987654321", 240, 2));

        centralita.GenerarInforme();
    }
}
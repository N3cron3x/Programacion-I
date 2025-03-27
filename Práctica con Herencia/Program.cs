// Clase base que representa una hamburguesa genérica
public class Hamburguesa
{
    // Propiedades básicas de la hamburguesa
    protected string TipoPan { get; set; }
    protected string TipoCarne { get; set; }
    protected decimal PrecioBase { get; set; }
    protected List<(string Ingrediente, decimal Precio)> IngredientesAdicionales { get; set; }
    protected int MaxIngredientes { get; set; }

    // Constructor que inicializa la hamburguesa básica
    public Hamburguesa(string tipoPan, string tipoCarne, decimal precioBase)
    {
        TipoPan = tipoPan;
        TipoCarne = tipoCarne;
        PrecioBase = precioBase;
        IngredientesAdicionales = new List<(string, decimal)>();
        MaxIngredientes = 4; // Por defecto permite 4 ingredientes adicionales
    }

    // Método para agregar ingredientes adicionales
    public virtual void AgregarIngrediente(string ingrediente, decimal precio)
    {
        if (IngredientesAdicionales.Count >= MaxIngredientes)
        {
            Console.WriteLine($"¡No se pueden agregar más ingredientes! Límite: {MaxIngredientes}");
            return;
        }
        
        IngredientesAdicionales.Add((ingrediente, precio));
        Console.WriteLine($"Ingrediente añadido: {ingrediente} (+${precio})");
    }

    // Método para mostrar el resumen de la hamburguesa y su precio total
    public virtual void MostrarResumen()
    {
        Console.WriteLine("\n--- RESUMEN DE HAMBURGUESA ---");
        Console.WriteLine($"Tipo de pan: {TipoPan}");
        Console.WriteLine($"Tipo de carne: {TipoCarne}");
        Console.WriteLine($"Precio base: ${PrecioBase}");

        decimal total = PrecioBase;
        
        if (IngredientesAdicionales.Count > 0)
        {
            Console.WriteLine("\nIngredientes adicionales:");
            foreach (var ingrediente in IngredientesAdicionales)
            {
                Console.WriteLine($"- {ingrediente.Ingrediente}: +${ingrediente.Precio}");
                total += ingrediente.Precio;
            }
        }

        Console.WriteLine($"\nTOTAL A PAGAR: ${total}");
    }
}

// Clase que representa una hamburguesa saludable (pan integral)
public class HamburguesaSaludable : Hamburguesa
{
    public HamburguesaSaludable(string tipoCarne, decimal precioBase) 
        : base("Integral", tipoCarne, precioBase)
    {
        MaxIngredientes = 6; // Permite hasta 6 ingredientes adicionales
    }

    // Método específico para agregar ingredientes saludables
    public void AgregarIngredienteSaludable(string ingrediente, decimal precio)
    {
        base.AgregarIngrediente(ingrediente, precio);
    }
}

// Clase que representa una hamburguesa premium (incluye papas y bebida)
public class HamburguesaPremium : Hamburguesa
{
    public HamburguesaPremium(string tipoCarne, decimal precioBase) 
        : base("Premium", tipoCarne, precioBase)
    {
        // Se agregan automáticamente los adicionales premium
        AgregarAdicionalesPremium();
        MaxIngredientes = 0; // No permite más ingredientes adicionales
    }

    // Método privado para agregar los adicionales premium
    private void AgregarAdicionalesPremium()
    {
        IngredientesAdicionales.Add(("Papas fritas", 2.50m));
        IngredientesAdicionales.Add(("Bebida", 1.80m));
    }

    // Sobreescribe el método para evitar agregar más ingredientes
    public override void AgregarIngrediente(string ingrediente, decimal precio)
    {
        Console.WriteLine("¡Las hamburguesas premium no permiten ingredientes adicionales!");
    }

    // Muestra el resumen incluyendo los adicionales premium
    public override void MostrarResumen()
    {
        Console.WriteLine("\n--- HAMBURGUESA PREMIUM ---");
        Console.WriteLine("Incluye papas fritas y bebida");
        base.MostrarResumen();
    }
}

// Programa principal para interactuar con el usuario
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("¡Bienvenido a Chimi MiBarriga del Sr. Billy Navaja!");
        Console.WriteLine("-----------------------------------------------\n");

        // Mostrar menú de opciones
        Console.WriteLine("Seleccione el tipo de hamburguesa:");
        Console.WriteLine("1. Hamburguesa Clásica");
        Console.WriteLine("2. Hamburguesa Saludable");
        Console.WriteLine("3. Hamburguesa Premium");
        Console.Write("\nOpción: ");

        Hamburguesa hamburguesa = null;
        int opcion = int.Parse(Console.ReadLine());

        // Configurar la hamburguesa según la selección
        switch (opcion)
        {
            case 1:
                hamburguesa = new Hamburguesa("Blanco", "Res", 5.00m);
                break;
            case 2:
                hamburguesa = new HamburguesaSaludable("Pollo", 6.50m);
                break;
            case 3:
                hamburguesa = new HamburguesaPremium("Angus", 8.00m);
                hamburguesa.MostrarResumen();
                return; // No necesita agregar ingredientes
            default:
                Console.WriteLine("Opción no válida");
                return;
        }

        Console.WriteLine("\n¿Desea agregar ingredientes adicionales? (S/N)");
        if (Console.ReadLine().ToUpper() == "S")
        {
            Console.WriteLine("\nIngredientes disponibles:");
            Console.WriteLine("1. Lechuga (+$0.50)");
            Console.WriteLine("2. Tomate (+$0.75)");
            Console.WriteLine("3. Bacon (+$1.50)");
            Console.WriteLine("4. Pepinillo (+$0.60)");
            Console.WriteLine("5. Queso (+$1.00)");
            Console.WriteLine("6. Cebolla (+$0.50)");
            Console.WriteLine("0. Terminar\n");

            bool continuar = true;
            while (continuar)
            {
                Console.Write("Seleccione un ingrediente (0 para terminar): ");
                int ingrediente = int.Parse(Console.ReadLine());

                switch (ingrediente)
                {
                    case 0:
                        continuar = false;
                        break;
                    case 1:
                        hamburguesa.AgregarIngrediente("Lechuga", 0.50m);
                        break;
                    case 2:
                        hamburguesa.AgregarIngrediente("Tomate", 0.75m);
                        break;
                    case 3:
                        hamburguesa.AgregarIngrediente("Bacon", 1.50m);
                        break;
                    case 4:
                        hamburguesa.AgregarIngrediente("Pepinillo", 0.60m);
                        break;
                    case 5:
                        hamburguesa.AgregarIngrediente("Queso", 1.00m);
                        break;
                    case 6:
                        hamburguesa.AgregarIngrediente("Cebolla", 0.50m);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }

        // Mostrar el resumen final
        hamburguesa.MostrarResumen();
    }
}
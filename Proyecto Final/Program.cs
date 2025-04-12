class Program
{
    static Usuario? usuario;
    static GestorTareas? gestor;

    static void Main(string[] args)
    {
        InicializarSistema();
        MostrarMenuPrincipal();
    }

    static void InicializarSistema()
    {
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        
        gestor = new GestorTareas();
#pragma warning disable CS8604 // Possible null reference argument.
        usuario = new Usuario(nombre);
#pragma warning restore CS8604 // Possible null reference argument.
        
        // Crear categorías por defecto
        usuario.CrearCategoria("Personal");
        usuario.CrearCategoria("Trabajo");
    }

    static void MostrarMenuPrincipal()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"\nSISTEMA DE TAREAS - Usuario: {usuario.Nombre}");
            Console.WriteLine("1. Ver todas las tareas");
            Console.WriteLine("2. Agregar nueva tarea");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Cambiar prioridad de tarea");
            Console.WriteLine("5. Salir");
            
            Console.Write("\nSeleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    usuario.MostrarTodasLasTareas();
                    break;
                case "2":
                    AgregarNuevaTarea();
                    break;
                case "3":
                    CompletarTarea();
                    break;
                case "4":
                    CambiarPrioridad();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void AgregarNuevaTarea()
    {
        Console.Clear();
        Console.WriteLine("\n--- NUEVA TAREA ---");
        
        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine();
        
        Console.Write("Prioridad (Alta/Media/Baja): ");
#pragma warning disable CS8604 // Possible null reference argument.
        Prioridad prioridad = gestor.ParsearPrioridad(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.
        
        Console.Write("Categoría (Personal/Trabajo): ");
        string categoriaNombre = Console.ReadLine();
        
        var categoria = usuario.Categorias.Find(c => c.Nombre.Equals(categoriaNombre, StringComparison.OrdinalIgnoreCase));
        if (categoria == null)
        {
            Console.WriteLine("Categoría no encontrada. Se asignará a Personal.");
            categoria = usuario.Categorias[0];
        }
        
#pragma warning disable CS8604 // Possible null reference argument.
        var nuevaTarea = gestor.CrearTarea(descripcion, prioridad);
#pragma warning restore CS8604 // Possible null reference argument.
        categoria.AgregarTarea(nuevaTarea);
        
        Console.WriteLine("\n¿Agregar fecha de vencimiento? (s/n)");
        if (Console.ReadLine().ToLower() == "s")
        {
            Console.Write("Fecha (dd/mm/aaaa): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaVencimiento))
            {
                gestor.AsignarFechaVencimiento(nuevaTarea, fechaVencimiento);
            }
        }
        
        Console.WriteLine("\n¡Tarea agregada con éxito!");
    }

    static void CompletarTarea()
    {
        Console.Clear();
        usuario.MostrarTodasLasTareas();
        
        Console.Write("\nIngrese el ID de la tarea a completar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            foreach (var categoria in usuario.Categorias)
            {
                var tarea = categoria.Tareas.Find(t => t.Id == id);
                if (tarea != null)
                {
                    tarea.MarcarComoCompletada();
                    Console.WriteLine($"Tarea {id} marcada como completada");
                    return;
                }
            }
            Console.WriteLine("Tarea no encontrada");
        }
        else
        {
            Console.WriteLine("ID inválido");
        }
    }

    static void CambiarPrioridad()
    {
        Console.Clear();
        usuario.MostrarTodasLasTareas();
        
        Console.Write("\nIngrese el ID de la tarea a modificar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Nueva prioridad (Alta/Media/Baja): ");
#pragma warning disable CS8604 // Possible null reference argument.
            Prioridad nuevaPrioridad = gestor.ParsearPrioridad(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.
            
            foreach (var categoria in usuario.Categorias)
            {
                var tarea = categoria.Tareas.Find(t => t.Id == id);
                if (tarea != null)
                {
                    tarea.CambiarPrioridad(nuevaPrioridad);
                    Console.WriteLine($"Prioridad de tarea {id} actualizada");
                    return;
                }
            }
            Console.WriteLine("Tarea no encontrada");
        }
        else
        {
            Console.WriteLine("ID inválido");
        }
    }
}
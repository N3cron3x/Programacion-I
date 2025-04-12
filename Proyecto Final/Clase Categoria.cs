public class Categoria
{
    public string Nombre { get; set; }
    public List<Tarea> Tareas { get; }

    public Categoria(string nombre)
    {
        Nombre = nombre;
        Tareas = new List<Tarea>();
    }

    public void AgregarTarea(Tarea tarea)
    {
        Tareas.Add(tarea);
    }

    public void MostrarTareas()
    {
        Console.WriteLine($"\n--- CATEGORÍA: {Nombre} ---");
        foreach (var tarea in Tareas)
        {
            Console.WriteLine(tarea);
        }
    }
}
public class Usuario
{
    public string Nombre { get; }
    public List<Categoria> Categorias { get; }

    public Usuario(string nombre)
    {
        Nombre = nombre;
        Categorias = new List<Categoria>();
    }

    public Categoria CrearCategoria(string nombre)
    {
        var nuevaCategoria = new Categoria(nombre);
        Categorias.Add(nuevaCategoria);
        return nuevaCategoria;
    }

    public void MostrarTodasLasTareas()
    {
        Console.WriteLine($"\nTAREAS DEL USUARIO: {Nombre}");
        foreach (var categoria in Categorias)
        {
            categoria.MostrarTareas();
        }
    }
}
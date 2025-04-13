// Añade al inicio del programa:
using System.Text.Json;

// Clase nueva para persistencia (Persistencia.cs)
public static class Persistencia
{
    private static readonly string archivo = "datos.json";
    
    public static void Guardar(Usuario usuario)
    {
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(usuario, opciones);
        File.WriteAllText(archivo, json);
    }
    
    public static Usuario? Cargar()
    {
        if(File.Exists(archivo))
        {
            string json = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<Usuario>(json);
        }
        return null;
    }
}
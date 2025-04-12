public class GestorTareas
{
    private int siguienteId = 1;
    
    public Tarea CrearTarea(string descripcion, Prioridad prioridad = Prioridad.Media)
    {
        return new Tarea(siguienteId++, descripcion, prioridad);
    }

    public void AsignarFechaVencimiento(Tarea tarea, DateTime fechaVencimiento)
    {
        tarea.FechaVencimiento = fechaVencimiento;
    }

    // Nueva función para parsear prioridad desde string
    public Prioridad ParsearPrioridad(string input)
    {
        return input.ToLower() switch
        {
            "alta" => Prioridad.Alta,
            "media" => Prioridad.Media,
            "baja" => Prioridad.Baja,
            _ => Prioridad.Media
        };
    }
}
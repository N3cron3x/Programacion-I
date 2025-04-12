public class Tarea
{
    public int Id { get; }
    public string Descripcion { get; set; }
    public bool Completada { get; private set; }
    public DateTime FechaCreacion { get; }
    public Prioridad Prioridad { get; set; }
    public DateTime? FechaVencimiento { get; set; }

    public Tarea(int id, string descripcion, Prioridad prioridad = Prioridad.Media)
    {
        Id = id;
        Descripcion = descripcion;
        Completada = false;
        FechaCreacion = DateTime.Now;
        Prioridad = prioridad;
    }

    public void MarcarComoCompletada()
    {
        Completada = true;
    }

    public void CambiarPrioridad(Prioridad nuevaPrioridad)
    {
        Prioridad = nuevaPrioridad;
    }

    public override string ToString()
    {
        string estado = Completada ? "[COMPLETADA]" : "[PENDIENTE]";
        string vencimiento = FechaVencimiento.HasValue ? $" | Vence: {FechaVencimiento.Value:dd/MM/yyyy}" : "";
        return $"[{Id}] {estado} ({Prioridad}) {Descripcion}{vencimiento} (Creada: {FechaCreacion:g})";
    }
}
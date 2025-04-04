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
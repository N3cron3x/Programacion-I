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

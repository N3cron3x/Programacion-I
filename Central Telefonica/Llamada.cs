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

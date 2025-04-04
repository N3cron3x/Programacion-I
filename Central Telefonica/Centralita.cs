// Clase que representa la centralita telefónica
    public class Centralita
    {
        private int contadorLlamadas;
        private double acumuladoCostes;
        private List<Llamada> llamadas;

        public Centralita()
        {
            llamadas = new List<Llamada>();
        }

        public void RegistrarLlamada(Llamada llamada)
        {
            llamadas.Add(llamada);
            contadorLlamadas++;
            acumuladoCostes += llamada.CalcularPrecio();
            Console.WriteLine(llamada);
        }

        public void GenerarInforme()
        {
            Console.WriteLine("\nInforme de la Centralita:");
            Console.WriteLine($"Total de Llamadas: {contadorLlamadas}");
            Console.WriteLine($"Facturación Total: {acumuladoCostes:C}");
            Console.WriteLine("");
        }
    }
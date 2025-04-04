    // Clase principal con el método Main
    class Practica2
    {
        static void Main(string[] args)
        {
            Centralita centralita = new Centralita();
            Console.WriteLine("");
            Console.WriteLine("Llamadas Recibidas:");
            centralita.RegistrarLlamada(new LlamadaLocal("8091234567", "8097654321", 120));
            centralita.RegistrarLlamada(new LlamadaProvincial("8291234567", "8097654321", 180, 1));
            centralita.RegistrarLlamada(new LlamadaLocal("8491234567", "8297654321", 60));
            centralita.RegistrarLlamada(new LlamadaProvincial("8091234567", "8497654321", 240, 2));

            centralita.GenerarInforme();
        }
    }
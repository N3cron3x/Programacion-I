namespace ComprobadorDeAñosBisiestos
{
    class Programa
    {
        static void Main(string[] args)
        {
            Console.Write("Por favor, introduce un año: ");
            string? entrada = Console.ReadLine();
            int añoIng;

            while (!int.TryParse(entrada, out añoIng) || añoIng < 1582)
            {
                Console.WriteLine("El año debe ser un número igual o mayor a 1582. Intenta nuevamente.");
                Console.Write("Introduce un año válido: ");
                entrada = Console.ReadLine();
            }

            string resultado = EsAñoBis(añoIng) 
                ? $"El año {añoIng} es un año bisiesto." 
                : $"El año {añoIng} no es un año bisiesto.";
            Console.WriteLine(resultado);

            static bool EsAñoBis(int año)
            {
                if (año % 400 == 0) return true;
                if (año % 100 == 0) return false;
                return año % 4 == 0;
            }
        }
    }
}

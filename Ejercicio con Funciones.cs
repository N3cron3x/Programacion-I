public class Program
{
    static void Main()
    {
        int año;

        while (true)
        {
            Console.WriteLine("Ingrese el año:");
            string entrada = Console.ReadLine();

           
            if (int.TryParse(entrada, out año) && año >= 0)
            {
                break; 
            }

            Console.WriteLine("Entrada inválida. Por favor, ingrese un año válido (un número mayor o igual a 0).");
        }

       
        if (año % 4 == 0 && (año % 100 != 0 || año % 400 == 0))
        {
            Console.WriteLine("El año es bisiesto.");
        }
        else
        {
            Console.WriteLine("El año no es bisiesto.");
        }
    }
}
Program.Main();
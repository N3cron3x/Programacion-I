class Program
{
    static bool EsPrimo(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
            if (num % i == 0) return false;
        return true;
    }

    static int ContarDigitosPares(int num)
    {
        return num.ToString().Count(c => "02468".Contains(c));
    }

    static bool IniciaConDigitoPrimo(int num)
    {
        return "2357".Contains(num.ToString()[0]);
    }

    static int Factorial(int n)
    {
        if (n < 0) return -1;
        if (n > 12) return -1;
        int fact = 1;
        for (int i = 2; i <= n; i++)
            fact *= i;
        return fact;
    }

    static void Main()
    {
        int[] arr = new int[10];
        Console.WriteLine("Ingrese 10 números enteros:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Ingrese el número {i + 1}:");
            string? input = Console.ReadLine();
            while (!int.TryParse(input, out arr[i]))
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo:");
                input = Console.ReadLine();
            }
        }

        // 1. Posición del mayor número
        int posMayor = Array.IndexOf(arr, arr.Max());
        Console.WriteLine($"Mayor número en posición: {posMayor + 1}");

        // 2. Posición del mayor número par
        int[] pares = arr.Where(x => x % 2 == 0).ToArray();
        int posMayorPar = pares.Length > 0 ? Array.IndexOf(arr, pares.Max()) : -1;
        Console.WriteLine($"Mayor número par en posición: {(posMayorPar != -1 ? posMayorPar + 1 : "Ninguno")}");

        // 3. Posición del mayor número primo
        int[] primos = arr.Where(EsPrimo).ToArray();
        int posMayorPrimo = primos.Length > 0 ? Array.IndexOf(arr, primos.Max()) : -1;
        Console.WriteLine($"Mayor número primo en posición: {(posMayorPrimo != -1 ? posMayorPrimo + 1 : "Ninguno")}");

        // 4. Cantidad de números que comienzan con dígito primo
        int cantInicioPrimo = arr.Count(IniciaConDigitoPrimo);
        Console.WriteLine($"Cantidad de números que inician con dígito primo: {cantInicioPrimo}");

        // 5. Posición del primo con más dígitos pares
        var primoMasPares = primos.OrderByDescending(ContarDigitosPares).FirstOrDefault();
        int posPrimoMasPares = primoMasPares != 0 ? Array.IndexOf(arr, primoMasPares) : -1;
        Console.WriteLine($"Primo con más dígitos pares en posición: {(posPrimoMasPares != -1 ? posPrimoMasPares + 1 : "Ninguno")}");

        // 6. Posiciones de números con más de 3 dígitos
        var posMasDe3Digitos = arr.Select((val, idx) => new { val, idx })
                                         .Where(x => Math.Abs(x.val) > 999)
                                         .Select(x => x.idx + 1)
                                         .ToArray();
        Console.WriteLine("Posiciones de números con más de 3 dígitos: " + (posMasDe3Digitos.Length > 0 ? string.Join(", ", posMasDe3Digitos) : "Ninguno"));

        // 7. Promedio entero del arreglo
        int promedio = (int)Math.Round(arr.Average());
        Console.WriteLine($"Promedio entero: {promedio}");

        // 8. Cantidad de números negativos
        int cantNegativos = arr.Count(x => x < 0);
        Console.WriteLine($"Cantidad de números negativos: {cantNegativos}");

        // 9. Factoriales de los números
        int[] factoriales = arr.Select(Factorial).ToArray();
        Console.WriteLine("Factoriales: " + string.Join(", ", factoriales.Select(f => f == -1 ? "Overflow" : f.ToString())));

        // 10. Determinar divisores exactos de un número ingresado
        Console.WriteLine("Ingrese un número para verificar sus divisores exactos en el arreglo:");
        string? inputNum = Console.ReadLine();
        int numDiv;
        while (!int.TryParse(inputNum, out numDiv))
        {
            Console.WriteLine("Entrada no válida. Intente de nuevo:");
            inputNum = Console.ReadLine();
        }

        int cantDivisores = arr.Count(x => x != 0 && numDiv % x == 0);
        Console.WriteLine($"Cantidad de divisores exactos en el arreglo: {cantDivisores}");
    }
}

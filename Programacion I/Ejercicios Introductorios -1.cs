// 1. Leer un número entero de dos dígitos y determinar a cuánto es igual la suma de sus dígitos.

Console.WriteLine("");
Console.WriteLine("Ejercicio 1");
Console.Write("Ingresa un número entero de dos dígitos: ");
int num1 = Convert.ToInt32(Console.ReadLine());
while (num1 < 10 || num1 > 99)
{
    Console.WriteLine("El número debe ser de dos dígitos.");
    Console.Write("Ingresa un número entero de dos dígitos: ");
    num1 = Convert.ToInt32(Console.ReadLine());
}
int suma = (num1 / 10) + (num1 % 10);
Console.WriteLine($"La suma de sus dígitos es: {suma}");

// 2. Leer un número entero de dos dígitos y determinar si es primo y además si es negativo.

Console.WriteLine("");
Console.WriteLine("Ejercicio 2");
Console.Write("Ingresa un número entero de dos dígitos: ");
int num2 = Convert.ToInt32(Console.ReadLine());
while (num2 < 10 || num2 > 99)
{
    Console.WriteLine("El número debe ser de dos dígitos.");
    Console.Write("Introduce un número entero de dos dígitos: ");
    num2 = Convert.ToInt32(Console.ReadLine());
}
bool esNegativo = num2 < 0;
bool EsPrimo(int n)
{
    if (n < 2) return false;
    for (int i = 2; i * i <= n; i++)
    {
        if (n % i == 0) return false;
    }
    return true;
}
bool esPrimo = EsPrimo(Math.Abs(num2));
Console.WriteLine($"El número {num2} es{(esNegativo ? " negativo" : " positivo")}. ");
Console.WriteLine($"El número {num2} {(esPrimo ? "es primo." : "no es primo.")}");

// 3. Leer un número entero de dos dígitos y determinar si sus dos dígitos son primos.

Console.WriteLine("");
Console.WriteLine("Ejercicio 3");
Console.Write("Ingresa un número entero de dos dígitos: ");
int num3 = Convert.ToInt32(Console.ReadLine());
while (num3 < 10 || num3 > 99)
{
    Console.WriteLine("El número debe ser de dos dígitos.");
    Console.Write("Ingresa un número entero de dos dígitos: ");
    num3 = Convert.ToInt32(Console.ReadLine());
}
int dig1 = num3 / 10;
int dig2 = num3 % 10;
if (EsPrimo(dig1) && EsPrimo(dig2))
    Console.WriteLine($"Ambos dígitos de {num3} son primos.");
else
    Console.WriteLine($"No ambos dígitos de {num3} son primos.");

// 4. Leer dos números enteros de dos dígitos y determinar si la suma de los dos números origina un número par.

Console.WriteLine("");
Console.WriteLine("Ejercicio 4");
Console.Write("Ingresa un primer número entero de dos dígitos: ");
int num4a = Convert.ToInt32(Console.ReadLine());
while (num4a < 10 || num4a > 99)
{
    Console.WriteLine("El número debe ser de dos dígitos.");
    Console.Write("Ingresa un primer número entero de dos dígitos: ");
    num4a = Convert.ToInt32(Console.ReadLine());
}
Console.Write("Ingresa un segundo número entero de dos dígitos: ");
int num4b = Convert.ToInt32(Console.ReadLine());
while (num4b < 10 || num4b > 99)
{
    Console.WriteLine("El número debe ser de dos dígitos.");
    Console.Write("Ingresa un segundo número entero de dos dígitos: ");
    num4b = Convert.ToInt32(Console.ReadLine());
}
suma = num4a + num4b;
Console.WriteLine($"La suma de {num4a} y {num4b} es {suma} y {(suma % 2 == 0 ? "es par" : "no es par")}.");

// 5. Leer un número entero de tres dígitos y determinar en qué posición está el mayor dígito.

Console.WriteLine("");
Console.WriteLine("Ejercicio 5");
Console.Write("Ingresa un número de tres dígitos: ");
int num5 = Convert.ToInt32(Console.ReadLine());
while (num5 < 100 || num5 > 999)
{
    Console.WriteLine("El número debe ser de tres dígitos.");
    Console.Write("Ingresa un número de tres dígitos: ");
    num5 = Convert.ToInt32(Console.ReadLine());
}
int c = num5 / 100;
int d = (num5 / 10) % 10;
int u = num5 % 10;
int posMayor = (c >= d && c >= u) ? 1 : (d >= c && d >= u) ? 2 : 3;
Console.WriteLine($"El dígito mayor está en la posición {posMayor}");
// 6. Leer un número entero de tres dígitos y determinar si algún dígito es múltiplo de los otros.

Console.WriteLine("");
Console.WriteLine("Ejercicio 6");
Console.Write("Ingresa un número entero de tres dígitos: ");
int numTres = Convert.ToInt32(Console.ReadLine());

while (numTres < 100 || numTres > 999)
{
    Console.WriteLine("El número debe ser de tres dígitos.");
    Console.Write("Ingresa un número entero de tres dígitos: ");
    numTres = Convert.ToInt32(Console.ReadLine());
}

int dig4 = numTres / 100;
int dig5 = (numTres / 10) % 10;
int dig3 = numTres % 10;

if ((dig1 != 0 && dig2 % dig1 == 0) || (dig1 != 0 && dig3 % dig1 == 0) ||
    (dig2 != 0 && dig1 % dig2 == 0) || (dig2 != 0 && dig3 % dig2 == 0) ||
    (dig3 != 0 && dig1 % dig3 == 0) || (dig3 != 0 && dig2 % dig3 == 0))
{
    Console.WriteLine("Algún dígito es múltiplo de otro.");
}
else
{
    Console.WriteLine("Ningún dígito es múltiplo de otro.");
}

// 7. Leer tres números enteros y determinar cuál es el mayor. Usar solamente dos variables.

Console.WriteLine("");
Console.WriteLine("Ejercicio 7");
Console.Write("Ingresa tres números enteros: ");
int mayor = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < 2; i++)
{
    int num = Convert.ToInt32(Console.ReadLine());
    if (num > mayor)
    {
        mayor = num;
    }
}

Console.WriteLine($"El número mayor es: {mayor}");

// 8. Leer un número entero de cinco dígitos y determinar si es un número Capicúa.

Console.WriteLine("");
Console.WriteLine("Ejercicio 8");
Console.Write("Ingresa un número de cinco dígitos: ");
int numCinco = Convert.ToInt32(Console.ReadLine());

while (numCinco < 10000 || numCinco > 99999)
{
    Console.WriteLine("El número debe ser de cinco dígitos.");
    Console.Write("Ingresa un número de cinco dígitos: ");
    numCinco = Convert.ToInt32(Console.ReadLine());
}

string strNum = numCinco.ToString();
char[] arr = strNum.ToCharArray();
Array.Reverse(arr);
string revNum = new string(arr);

if (strNum == revNum)
{
    Console.WriteLine("El número es Capicúa.");
}
else
{
    Console.WriteLine("El número no es Capicúa.");
}

// 9. Leer un número entero de cuatro dígitos y determinar si el segundo dígito es igual al penúltimo.

Console.WriteLine("");
Console.WriteLine("Ejercicio 9");
Console.Write("Ingresa un número de cuatro dígitos: ");
int numCuatro = Convert.ToInt32(Console.ReadLine());

while (numCuatro < 1000 || numCuatro > 9999)
{
    Console.WriteLine("El número debe ser de cuatro dígitos.");
    Console.Write("Ingresa un número de cuatro dígitos: ");
    numCuatro = Convert.ToInt32(Console.ReadLine());
}

int segDig = (numCuatro / 100) % 10;
int penDig = (numCuatro / 10) % 10;

if (segDig == penDig)
{
    Console.WriteLine("El segundo dígito es igual al penúltimo.");
}
else
{
    Console.WriteLine("El segundo dígito no es igual al penúltimo.");
}

// 10. Leer dos números enteros y si la diferencia entre los dos es menor o igual a 10, mostrar todos los enteros entre el menor y el mayor.

Console.WriteLine("");
Console.WriteLine("Ejercicio 10");
Console.Write("Ingresa el primer número entero: ");
int num6 = Convert.ToInt32(Console.ReadLine());

Console.Write("Ingresa el segundo número entero: ");
int num7 = Convert.ToInt32(Console.ReadLine());

int menor = Math.Min(num1, num2);
int mayorNum = Math.Max(num1, num2);

if ((mayorNum - menor) <= 10)
{
    Console.WriteLine("Los números en el rango son:");
    for (int i = menor; i <= mayorNum; i++)
    {
        Console.Write(i + " ");
    }
}
else
{
    Console.WriteLine("La diferencia es mayor a 10.");
}

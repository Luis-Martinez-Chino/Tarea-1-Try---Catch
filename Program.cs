using System;

class Program
{
    static void Main()
    {


        //EJERCICIO 1: Manejo de Excepciones en C#
        Console.WriteLine("EJERCICIO 1 =======================================================================");
        Console.WriteLine();

        bool salir = false;

        while (salir == false)
        {
            try
            {
                Console.Write("Ingrese un número real: ");
                double numero = Convert.ToDouble(Console.ReadLine());

                // 1. Manejo de operación inexistente
                if (numero < 0)
                {
                    Console.WriteLine("Error: No se puede calcular la raíz de un número negativo.");
                }
                else
                {
                    // 2. Potencia al cuadrado
                    double cuadrado = numero * numero;

                    // 3. Raíz cuadrada
                    double raiz = 0;
                    if (numero > 0)
                    {
                        raiz = numero;
                        for (int i = 0; i < 10; i++)
                        {
                            raiz = 0.5 * (raiz + (numero / raiz));
                        }
                    }

                    Console.WriteLine("La potencia al cuadrado es: " + cuadrado);
                    Console.WriteLine("La raíz cuadrada es: " + raiz);

                    salir = true; // Salimos del ciclo 
                }
            }
            catch (FormatException)
            {
                // Manejo de entrada con formato incorrecto, como letras o símbolos en lugar de números
                Console.WriteLine("Error: Por favor ingrese un número válido.");
            }

            Console.WriteLine();
        }

        Console.ReadLine();



        //EJERCICIO 2: Detección de Hiato en Palabras
        Console.WriteLine("EJERCICIO 2 =======================================================================");
        Console.WriteLine();

        try
        {
            Console.WriteLine("Ingrese una palabra:");
            string texto = Console.ReadLine();

            // Manejo de cadena
            if (texto == "")
            {
                // Salta directamente al bloque catch de abajo
                throw new NullReferenceException();
            }

            string palabra = texto.ToLower();
            bool resultado = false;

            // Recorrer la palabra letra por letra
            for (int i = 0; i < palabra.Length - 1; i++)
            {
                char letra1 = palabra[i];
                char letra2 = palabra[i + 1];

                // REGLA: Dos vocales iguales
                if ((letra1 == 'a' && letra2 == 'a') || (letra1 == 'e' && letra2 == 'e') ||
                    (letra1 == 'o' && letra2 == 'o') || (letra1 == 'i' && letra2 == 'i') ||
                    (letra1 == 'u' && letra2 == 'u'))
                {
                    resultado = true;
                }

                // REGLA: Vocales abiertas (a, e, o, á, é, ó) juntas
                bool esAbierta1 = (letra1 == 'a' || letra1 == 'e' || letra1 == 'o' || letra1 == 'á' || letra1 == 'é' || letra1 == 'ó');
                bool esAbierta2 = (letra2 == 'a' || letra2 == 'e' || letra2 == 'o' || letra2 == 'á' || letra2 == 'é' || letra2 == 'ó');

                if (esAbierta1 && esAbierta2)
                {
                    resultado = true;
                }

                // REGLA: Vocal cerrada tónica (í, ú) + abierta o viceversa
                bool esCerradaTonica1 = (letra1 == 'í' || letra1 == 'ú');
                bool esCerradaTonica2 = (letra2 == 'í' || letra2 == 'ú');

                if ((esCerradaTonica1 && esAbierta2) || (esAbierta1 && esCerradaTonica2))
                {
                    resultado = true;
                }
            }

            Console.WriteLine("¿Tiene hiato?: " + resultado);
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Error: La cadena está vacía.");
        }

        Console.ReadLine();



        //EJERCICIO 3: Manejo de Excepciones con Arreglos
        Console.WriteLine("EJERCICIO 3 =======================================================================");
        Console.WriteLine();

        // Arreglo con los colores indicados
        string[] colores = { "Rojo", "Azul", "Amarillo", "Verde", "Blanco", "Violeta", "Naranja" };

        try
        {
            Console.WriteLine("Ingrese un número entero entre 0 y 9:");
            // 1. Manejo de formato incorrecto
            int posicion = Convert.ToInt32(Console.ReadLine());

            // Revisamos que esté en el rango de 0 a 9
            if (posicion < 0 || posicion > 9)
            {
                Console.WriteLine("Error: El número debe estar entre 0 y 9.");
            }
            else
            {
                // Intentamos mostrar el color. 
                // Si el número es 7, 8 o 9, irá al catch.
                Console.WriteLine("El color en la posición " + posicion + " es: " + colores[posicion]);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: No ingresaste un número entero válido.");
        }
        catch (IndexOutOfRangeException)
        {
            // 2. Manejo de posición inválida
            Console.WriteLine("Error: Esa posición no existe en el arreglo de colores.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
        }

        Console.ReadLine();
    }
}
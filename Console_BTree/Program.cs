using System;

namespace Console_BTree
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\t..::Ábol B en Disco::..\n\n");
                Console.WriteLine("1)Ingresar valores");
                Console.WriteLine("Salir");
                int resultado = 0;
                int.TryParse(Console.ReadLine(), out resultado);
                if (resultado == 1)
                {
                    //Insertar
                    Console.Write("Ingrese el valor a insertar: ");
                    int ingresado = 0;
                    int.TryParse(Console.ReadLine(), out ingresado);
                    //Llamar árbol
                }
                else if (resultado == 2)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Ingresa un valor válido");
                }
            }
        }
    }
}

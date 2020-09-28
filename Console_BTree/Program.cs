using System;

namespace Console_BTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t..::Ábol B en Disco::..\n\n");
            Console.WriteLine("Ingrese el grado del árbol");
            var grado = Convert.ToInt16(Console.ReadLine());
            //var Arbol = new ArbolB<int>(grado);

            while (true)
            {

                Console.WriteLine("\n1) Ingresar valores");
                Console.WriteLine("2) Salir \n");
                int resultado = 0;
                int.TryParse(Console.ReadLine(), out resultado);
                if (resultado == 1)
                {
                    //Insertar
                    Console.Write("Ingrese el valor a insertar: ");
                    int ingresado = 0;
                    int.TryParse(Console.ReadLine(), out ingresado);
                    //Llamar árbol
                    //ArbolB<string> arbolB = new ArbolB<string>(grado);
                    string ingresado1 = $"{ingresado:0000;-000}";
                    //arbolB.Insert(ingresado1);
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

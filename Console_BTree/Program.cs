using System;
using Bib_BTree;
using System.Collections.Generic;

namespace Console_BTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t..::Ábol B en Disco::..\n\n");
            Console.WriteLine("Ingrese el grado del árbol");

            var ListValues = new List<string>();
            ListValues.Add("1");
            ListValues.Add("2");
            ListValues.Add("3");
            
            

            var grado = Convert.ToInt16(Console.ReadLine());
            var Node = new Nodo<string>(grado);

            var listMedio = Node.ArregloValoresMayores(ListValues);
            var valorMedio = Node.ValorMedioS(ListValues);

            foreach (var item in listMedio)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(valorMedio);

            Console.ReadLine();


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
                    ArbolB<string> arbolB = new ArbolB<string>(grado);
                    string ingresado1 = $"{ingresado:0000;-000}";
                    arbolB.Insert(ingresado1);
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

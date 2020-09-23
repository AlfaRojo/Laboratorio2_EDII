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
            var grado = Convert.ToInt16(Console.ReadLine());
            var Arbol = new ArbolB<int>(grado);
            var NodoRaiz = new NodoM<int>(grado);
            var NodoHijo1 = new NodoM<int>(grado);
            var NodoHijo2 = new NodoM<int>(grado);

            
            NodoRaiz.Values.Add(41);
            NodoHijo1.Values.Add(5);
            NodoHijo2.Values.Add(48);
            NodoHijo2.Values.Add(62);
            NodoRaiz.Children.Add(NodoHijo1);
            NodoRaiz.Children.Add(NodoHijo2);
            

            NodoRaiz = NodoRaiz.InsertTree(NodoRaiz, null, 70);


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

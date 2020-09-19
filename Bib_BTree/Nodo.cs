using System;
using System.IO;
using System.Collections.Generic;



namespace Bib_BTree
{
    public class Nodo<T> where T : IComparable
    {
        public int grado { get; set; }
        public int Id { get; set; }
        public int Father { get; set; }
        public List<T> Values { get; set; }
        public List<int> Children { get; set; }

        public int SizeNodoLenght => 5 * (grado - 1) + (grado * 5) + 4 + 4 + 5;

        public Nodo(int grado)
        {
            Values = new List<T>();
            Children = new List<int>();
            this.grado = grado;
        }

        public Nodo<T> Insert(T Value, string Id)
        {

        }

        public Nodo<T> GetChildren(string idActual)
        {
            Nodo<T> NodoActual = new Nodo<T>(grado);
            using (StreamReader SR = new StreamReader("/Users/eber.g/Desktop/PrimerAño/2Ciclo2020/EstructuraDatos II/Laboratorios/Laboratorio_3/Laboratorio2_EDII/Bib_BTree/Archivos/ArbolDisco.txt"))
            {
                string Line;

                while((Line = SR.ReadLine()) != null)
                {
                    var idArchivo = Line.Substring(0, 4);
                    if(idActual == idArchivo)
                    {
                        NodoActual.Id = Convert.ToInt32(idArchivo);
                        NodoActual.Father = Convert.ToInt32(Line.Substring(6, 9));
                        string hijos = Line.Substring(10, grado*5);
                        string[] ListadoHijos = hijos.Split(';');
                        for (int i = 0; i < ListadoHijos.Length; i++)
                        {
                            if(ListadoHijos[i] == "0000")
                            {
                                NodoActual.Children[i] = -1;
                            }
                        }

                        string ValuesString = Line.Substring(grado*5, SizeNodoLenght);
                        var j = 0;
                        var p = 4;
                      
                    }
                }
            }

            return NodoActual;

        }

    }
}

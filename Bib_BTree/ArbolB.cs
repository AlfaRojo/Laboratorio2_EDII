using System;
using System.IO;
using System.Collections.Generic;

namespace Bib_BTree
{
    public class ArbolB<T> where T : IComparable
    {
        public Nodo<T> Root { get; set; }
        public int Grado { get; set; }

        public ArbolB(int grado)
        {
            this.Grado = grado;
        }

        public void Insert(T Value)
        {
            if (Root == null)
            {
                Root = new Nodo<T>(Grado);
                FileHandling<T> fileHandling = new FileHandling<T>();
                Root.Insert(Value, fileHandling.Obtener_Raiz(GetRoot()));

            }
        }

        public string GetRoot()
        {
            var RootString = "";

            using (StreamReader SR = new StreamReader("/Users/eber.g/Desktop/PrimerAño/2Ciclo2020/EstructuraDatos II/Laboratorios/Laboratorio_3/Laboratorio2_EDII/Bib_BTree/Archivos/ArbolDisco.txt"))
            {
                var Line = SR.ReadLine();
                RootString = Line.Substring(0, 4);
            }
            return RootString;
        }
    }
}

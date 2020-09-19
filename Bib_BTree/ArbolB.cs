using System;
using System.IO;

namespace Bib_BTree
{
    public class ArbolB<T> where T : IComparable
    {
        public Nodo<T> Root { get; set; }

        public ArbolB()
        {
            
        }

        public void Insert(T Value)
        {
            if(Root == null)
            {
                Root = new Nodo<T>();
                Root.Insert(Value, GetRoot());
            }
        }

        public string GetRoot()
        {
            var RootString = "";

            using(StreamReader SR = new StreamReader("/Users/eber.g/Desktop/PrimerAño/2Ciclo2020/EstructuraDatos II/Laboratorios/Laboratorio_3/Laboratorio2_EDII/Bib_BTree/Archivos/ArbolDisco.txt"))
            {
                var Line = SR.ReadLine();
                RootString = Line.Substring(0, 4);
            }

            return RootString;
        }
          

    }
}

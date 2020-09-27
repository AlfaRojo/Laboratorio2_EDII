using System;
using System.IO;
using System.Collections.Generic;

namespace Bib_BTree
{
    public class ArbolB<TKey, T> where TKey : IComparable<TKey>
    {
        public ArbolB<TKey, T> Raiz { get; set; }
        public int Grado { get; set; }

        public ArbolB(int grado)
        {
            this.Grado = grado;
        }

        public void Insertar(TKey new_key, T nuevoApuntador)
        {
            InsertarRecursivo(this.Raiz, new_key, nuevoApuntador, null);
        }

        private void InsertarRecursivo(ArbolB<TKey, T> nodo, TKey nuevaLlave, T nuevoApuntador, ArbolB<TKey, T> nodoPadre)
        {
            int posicionInsertar = nodo.Entradas.TakeWhile(entry => nuevaLlave.CompareTo(entry.LLave) >= 0).Count();
            //Es hoja
            if (nodo.EsHoja)
            {
                if (this.Raiz == nodo)
                {
                    this.Raiz.Entradas.Insert(posicionInsertar, new Entry<TKey, T>() { LLave = nuevaLlave, Apuntador = nuevoApuntador });
                    if (this.Raiz.AlcanzaMaximaEntrada)
                    {
                        // nuevo nodo y se necesita dividir
                        ArbolB<TKey, T> viejaRaiz = this.Raiz;
                        this.Raiz = new BNodo<TKey, T>(this.Grado);
                        this.Raiz.Hijos.Add(viejaRaiz);
                        this.DividirHijo(this.Raiz, 0, viejaRaiz);
                        this.Altura++;
                    }
                    return;
                }
                else
                {
                    nodo.Entradas.Insert(posicionInsertar, new Entry<TKey, T>() { LLave = nuevaLlave, Apuntador = nuevoApuntador });
                    if (nodo.AlcanzaMaximaEntrada)
                    {
                        posicionInsertar = nodoPadre.Entradas.TakeWhile(entry => nuevaLlave.CompareTo(entry.LLave) >= 0).Count();
                        DividirHijo(nodoPadre, posicionInsertar, nodo);
                    }
                    return;
                }
            }
            //No es Hoja
            else
            {
                this.InsertarRecursivo(nodo.Hijos[posicionInsertar], nuevaLlave, nuevoApuntador, nodo);
                if (nodoPadre == null)
                {
                    if (nodo.AlcanzaMaximaEntrada)
                    {
                        ArbolB<TKey, T> viejaRaiz = this.Raiz;
                        this.Raiz = new BNodo<TKey, T>(this.Grado);
                        this.Raiz.Hijos.Add(viejaRaiz);
                        this.DividirHijo(this.Raiz, 0, viejaRaiz);
                        this.Altura++;
                    }
                    return;
                }
                else
                {
                    if (nodo.AlcanzaMaximaEntrada)
                    {
                        DividirHijo(nodoPadre, posicionInsertar, nodo);
                    }
                    return;
                }
            }

        }

        private void DividirHijo(ArbolB<TKey, T> padreNodo, int nodoCorrer, ArbolB<TKey, T> nodoMover)
        {

            var nuevoNodo = new ArbolB<TKey, T>(this.Grado);
            if (Grado % 2 == 0)
            {
                padreNodo.Entradas.Insert(nodoCorrer, nodoMover.Entradas[(this.Grado / 2) - 1]);
            }
            else
            {
                padreNodo.Entradas.Insert(nodoCorrer, nodoMover.Entradas[(this.Grado / 2)]);
            }

            if (Grado % 2 == 0)
            {
                nuevoNodo.Entradas.AddRange(nodoMover.Entradas.GetRange((this.Grado / 2), (this.Grado / 2)));
                nodoMover.Entradas.RemoveRange((this.Grado / 2) - 1, (this.Grado / 2) + 1);
            }
            else
            {
                nuevoNodo.Entradas.AddRange(nodoMover.Entradas.GetRange((this.Grado / 2) + 1, this.Grado / 2));
                nodoMover.Entradas.RemoveRange((this.Grado / 2), (this.Grado / 2) + 1);
            }
            if (!nodoMover.EsHoja)
            {
                if (Grado % 2 == 0)
                {
                    nuevoNodo.Hijos.AddRange(nodoMover.Hijos.GetRange((this.Grado / 2), (this.Grado / 2) + 1));
                    nodoMover.Hijos.RemoveRange((this.Grado / 2), (this.Grado / 2) + 1);
                }
                else
                {
                    nuevoNodo.Hijos.AddRange(nodoMover.Hijos.GetRange((this.Grado / 2) + 1, (this.Grado / 2) + 1));
                    nodoMover.Hijos.RemoveRange((this.Grado / 2) + 1, (this.Grado / 2) + 1);
                }
            }
            padreNodo.Hijos.Insert(nodoCorrer + 1, nuevoNodo);
        }


        #region Anterior
        //public void Insert(T Value)
        //{
        //    if (Root == null)
        //    {
        //        Root = new Nodo<T>(Grado);
        //        FileHandling<T> fileHandling = new FileHandling<T>();
        //        //Root.Insert(Value, fileHandling.Obtener_Raiz(GetRoot()));

        //    }
        //}

        //public string GetRoot()
        //{
        //    var RootString = "";

        //    using (StreamReader SR = new StreamReader("/Users/eber.g/Desktop/PrimerAño/2Ciclo2020/EstructuraDatos II/Laboratorios/Laboratorio_3/Laboratorio2_EDII/Bib_BTree/Archivos/ArbolDisco.txt"))
        //    {
        //        var Line = SR.ReadLine();
        //        RootString = Line.Substring(0, 4);
        //    }
        //    return RootString;
        //}
        #endregion
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Bib_BTree.Helper;

namespace Bib_BTree
{
    public class ArbolB<TKey, T> where TKey: IComparable<TKey>
    {
        public Nodo<TKey, T> Raiz { get; set; }
        public int Grado { get; set; }
        public int Altura { get; private set; }

        public ArbolB(int grado)
        {
            this.Raiz = new Nodo<TKey, T>(grado);
            this.Grado = grado;
            this.Altura = 1;
        }

        public void Insertar(TKey new_key, T nuevoApuntador)
        {
            InsertarRecursivo(this.Raiz, new_key, nuevoApuntador, null);
        }

        private void InsertarRecursivo(Nodo<TKey, T> nodo, TKey nuevaLlave, T nuevoApuntador, Nodo<TKey, T> nodoPadre)
        {
            int posicionInsertar = nodo.Entradas.TakeWhile(entry => nuevaLlave.CompareTo(entry.LLave) >= 0).Count();
            //Es hoja
            if (nodo.EsHoja)
            {
                if (this.Raiz == nodo)
                {
                    this.Raiz.Entradas.Insert(posicionInsertar, new BEntry<TKey, T>() { LLave = nuevaLlave, Apuntador = nuevoApuntador });
                    if (this.Raiz.AlcanzaMaximaEntrada)
                    {
                        // nuevo nodo y se necesita dividir
                        Nodo<TKey, T> viejaRaiz = this.Raiz;
                        this.Raiz = new Nodo<TKey, T>(this.Grado);
                        this.Raiz.Children.Add(viejaRaiz);
                        this.DividirHijo(this.Raiz, 0, viejaRaiz);
                        this.Altura++;
                    }
                    return;
                }
                else
                {
                    nodo.Entradas.Insert(posicionInsertar, new BEntry<TKey, T>() { LLave = nuevaLlave, Apuntador = nuevoApuntador });
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
                this.InsertarRecursivo(nodo.Children[posicionInsertar], nuevaLlave, nuevoApuntador, nodo);
                if (nodoPadre == null)
                {
                    if (nodo.AlcanzaMaximaEntrada)
                    {
                        Nodo<TKey, T> viejaRaiz = this.Raiz;
                        this.Raiz = new Nodo<TKey, T>(this.Grado);
                        this.Raiz.Children.Add(viejaRaiz);
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

        private void DividirHijo(Nodo<TKey, T> padreNodo, int nodoCorrer, Nodo<TKey, T> nodoMover)
        {

            var nuevoNodo = new Nodo<TKey, T>(this.Grado);
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
                    nuevoNodo.Children.AddRange(nodoMover.Children.GetRange((this.Grado / 2), (this.Grado / 2) + 1));
                    nodoMover.Children.RemoveRange((this.Grado / 2), (this.Grado / 2) + 1);
                }
                else
                {
                    nuevoNodo.Children.AddRange(nodoMover.Children.GetRange((this.Grado / 2) + 1, (this.Grado / 2) + 1));
                    nodoMover.Children.RemoveRange((this.Grado / 2) + 1, (this.Grado / 2) + 1);
                }
            }
            padreNodo.Children.Insert(nodoCorrer + 1, nuevoNodo);
        }
        private BEntry<TKey, T> BusquedaInterna(Nodo<TKey, T> node, TKey key)
        {
            int i = node.Entradas.TakeWhile(entry => key.CompareTo(entry.LLave) > 0).Count();

            if (i < node.Entradas.Count && node.Entradas[i].LLave.CompareTo(key) == 0)
            {
                return node.Entradas[i];
            }
            return node.EsHoja ? null : this.BusquedaInterna(node.Children[i], key);
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

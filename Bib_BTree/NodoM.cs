using System;
using System.Collections.Generic;

namespace Bib_BTree
{
    public class NodoM<T> where T : IComparable
    {
        public int grado { get; set; }
        public int Id { get; set; }
        public int Father { get; set; }
        public List<T> Values { get; set; }
        public List<int> Children { get; set; }

        public NodoM(int grado)
        {
            Values = new List<T>();
            Children = new List<int>();
            this.grado = grado;
        }

        public NodoM<T> InsertTree(NodoM<T> Actual, List<int> Children, T Nuevo)
        {
            if(Actual.Children.Count == 0)
            {
                if(Actual.Values.Count < grado - 1)
                {
                    Actual.Values.Add(Nuevo);
                    Actual.Values.Sort();
                }
                else if(Children.Count > 0)
                {
                    
                }
                else
                {
                    SplitTree(Actual, Actual.Children, Nuevo);
                }
                
            }
            return Actual;
        }

        public NodoM<T> SplitTree(NodoM<T> Actual, List<int> Children,T Nuevo)
        {
            if (Actual.Father == -1)
            {
                Actual.Values.Add(Nuevo);
                Actual.Values.Sort();
                int posicion = (grado % 2 == 0) ? (grado / 2) - 1 : (grado - 1) / 2;
                var FileHandling = new FileHandling<T>();
                var metadata = FileHandling.Obtener_Metadata();
                var ArregloM = ArregloValoresMayores(Actual.Values);
                var ValorM = ValorMedioS(Actual.Values);


                //NodoNuevo
                Nodo<T> Nuevo1 = new Nodo<T>(grado);
                Nuevo1.Id = Convert.ToInt32(metadata[2]);
                Nuevo1.Father = Nuevo1.Id + 1;
                for (int i = 0; i < ValorM.Count; i++)
                {
                    Nuevo1.Values[i] = ValorM[i];
                }

                //NodoAnterior
                NodoM<T> Anterior = new NodoM<T>(grado);
                Anterior.Id = Actual.Id;
                Anterior.Father = Nuevo1.Id + 1;
                for (int i = 0; i < posicion; i++)
                {
                    Anterior.Values[i] = Actual.Values[i];
                }

                //Raiz
                NodoM<T> Raiz = new NodoM<T>(grado);
                Raiz.Id = Convert.ToInt32(metadata[2]) + 1;
                for (int i = 0; i < ValorM.Count; i++)
                {
                    Raiz.Values[i] = ValorM[i];
                }

                Raiz.Children.Add(Anterior.Id);
                Raiz.Children.Add(Nuevo1.Id);

                return Raiz;
            }









        }

        public List<T> ArregloValoresMayores(List<T> values)
        {
            var ArregloValoresM = new List<T>();

            if (grado % 2 == 0)
            {
                var ValoresMinimos = (grado / 2) - 1;

                for (int i = 0; i < ValoresMinimos; i++)
                {
                    ArregloValoresM.Add(values[(values.Count - 1) - i]);
                }
                return ArregloValoresM;
            }
            else
            {
                var PosicionMedia = ((grado - 1) / 2) + 1;
                for (int i = PosicionMedia; i < values.Count; i++)
                {
                    ArregloValoresM.Add(values[i]);
                }
                return ArregloValoresM;
            }
        }

        public List<T> ValorMedioS(List<T> values)
        {
            var valorMedio = new List<T>();

            if (grado % 2 == 0)
            {
                var ValoresMinimos = (grado / 2) - 1;

                int i;
                for (i = 0; i < ValoresMinimos + 1; i++)
                {
                    if (i == ValoresMinimos)
                    {
                        valorMedio.Add(values[(values.Count - 1) - i]);
                        return valorMedio;
                    }
                }


            }
            else
            {
                var PosicionMedia = (grado - 1) / 2;

                for (int i = 0; i < PosicionMedia + 1; i++)
                {
                    if (i == PosicionMedia)
                    {
                        valorMedio.Add(values[PosicionMedia]);
                        return valorMedio;
                    }
                }
            }
            return valorMedio;
        }


    }
}

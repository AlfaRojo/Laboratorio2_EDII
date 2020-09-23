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
        public List<NodoM<T>> Children { get; set; }

        public NodoM(int grado)
        {
            Values = new List<T>();
            Children = new List<NodoM<T>>(grado);
            this.grado = grado;
        }

        public NodoM<T> InsertTree(NodoM<T> Actual, NodoM<T> Intermedio, T Nuevo)
        {
            if(Actual.Children.Count == 0)
            {
                if(Actual.Values.Count < grado - 1)
                {
                    Actual.Values.Add(Nuevo);
                    Actual.Values.Sort();

                    //Modificar Archivo
                    return Actual;
                }
                else
                {
                    SplitTree(Actual, Intermedio, Nuevo);
                }
            }
            else
            {
                int i;
                for (i = 0; i < Actual.Values.Count; i++)
                {
                    if(Actual.Values[i].CompareTo(Nuevo) == -1)
                    {
                        InsertTree(Actual.Children[i], Children[i], Nuevo);
                    }
                }
                if (i == Actual.Values.Count)
                {
                    InsertTree(Actual.Children[i], Actual, Nuevo);
                }
            }
            return Actual;
        }

        public NodoM<T> SplitTree(NodoM<T> Actual, NodoM<T> Intermedio,T Nuevo)
        {
            if (Actual.Children.Count == 0)
            {
                Nodo<T> NodoS = new Nodo<T>(grado);
                for (int i = 0; i < Actual.Values.Count + 1; i++)
                {
                    NodoS.Values[i] = Actual.Values[i];
                    if (i == Actual.Values.Count) NodoS.Values[i] = Nuevo;
                }
                NodoS.Values.Sort();


                int posicion = (grado % 2 == 0) ? (grado / 2) - 1 : (grado - 1) / 2;
                var FileHandling = new FileHandling<T>();
                var metadata = FileHandling.Obtener_Metadata();
                var ArregloM = ArregloValoresMayores(NodoS.Values);
                var ValorM = ValorMedioS(NodoS.Values);


                //NodoNuevo
                NodoM<T> Nuevo1 = new NodoM<T>(grado);
                Nuevo1.Id = Convert.ToInt32(metadata[2]);
                Nuevo1.Father = Nuevo1.Id + 1;
                for (int i = 0; i < ArregloM.Count; i++)
                {
                    Nuevo1.Values[i] = ArregloM[i];
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
                
                Raiz.Children.Add(Anterior);
                Raiz.Children.Add(Nuevo1);

                //Mandar la nueva informacion al archivo
                return Raiz;
            }
            else
            {
                Nodo<T> NodoS = new Nodo<T>(grado);
                for (int X = 0; X < Actual.Values.Count + 1; X++)
                {
                    NodoS.Values[X] = Actual.Values[X];
                    if (X == Actual.Values.Count) NodoS.Values[X] = Nuevo;
                }
                NodoS.Values.Sort();


                int posicion = (grado % 2 == 0) ? (grado / 2) - 1 : (grado - 1) / 2;
                var FileHandling = new FileHandling<T>();
                var metadata = FileHandling.Obtener_Metadata();
                var ArregloM = ArregloValoresMayores(NodoS.Values);
                var ValorM = ValorMedioS(NodoS.Values);

                //NodoNuevo
                NodoM<T> Nuevo1 = new NodoM<T>(grado);
                Nuevo1.Id = Convert.ToInt32(metadata[2]);
                Nuevo1.Father = Convert.ToInt32(metadata[1]); //Preguntar si es la raiz
                for (int X = 0; X < ArregloM.Count; X++)
                {
                    Nuevo1.Values[X] = ArregloM[X];
                }

                //NodoAnterior
                NodoM<T> Anterior = new NodoM<T>(grado);
                Anterior.Id = Actual.Id;
                Anterior.Father = Nuevo1.Id + 1;
                for (int X = 0; X < posicion; X++)
                {
                    Anterior.Values[X] = Actual.Values[X];
                }

                //Obtener la raiz
                int i;

                if (Intermedio.Values.Count < grado)
                {
                    for (i = 0; i < Intermedio.Values.Count; i++)
                    {
                        if (Intermedio.Values[i].CompareTo(ValorM) == -1)
                        {
                            if (Intermedio.Children[i + 1] != null)
                            {
                                Intermedio.Values.Add(Nuevo);
                                Intermedio.Values.Sort();
                                //CorrerMisHijos
                                for (int j = Intermedio.Children.Count; j > Intermedio.Children.Count - 1; j--)
                                {
                                    Intermedio.Children[j] = Children[j];
                                }

                                Intermedio.Children[i] = Children[i];
                            }



                        }
                    }
                }
                else
                {
                    SplitTree(Intermedio, Intermedio, Nuevo);
                }



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

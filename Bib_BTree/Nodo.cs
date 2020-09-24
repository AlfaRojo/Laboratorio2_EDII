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
        public List<T> Children { get; set; }

        public int SizeNodoLenght => 5 * (grado - 1) + (grado * 5) + 4 + 4 + 5;

        public Nodo(int grado)
        {
            Values = new List<T>();
            Children = new List<T>();
            this.grado = grado;
        }

        public List<string> ArregloValoresMayores(List<string> values)
        {
            var ArregloValoresM = new List<string>();

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
                var PosicionMedia = ((grado - 1) / 2) + 1 ;
                for (int i = PosicionMedia; i < values.Count; i++)
                {
                    ArregloValoresM.Add(values[i]);
                }
                return ArregloValoresM;
            }
        }

        public string ValorMedioS(List<string> values)
        {
            string valorMedio = "";

            if (grado % 2 == 0)
            {
                var ValoresMinimos = (grado / 2) - 1;
                
                int i;
                for (i = 0; i < ValoresMinimos + 1; i++)
                {
                    if (i == ValoresMinimos)
                    {
                        valorMedio = values[(values.Count - 1) - i];
                        return valorMedio;
                    }
                }

               
            }
            else
            {
                var PosicionMedia = (grado - 1) / 2;

                for (int i = 0; i < PosicionMedia + 1; i++)
                {
                    if(i == PosicionMedia)
                    {
                        valorMedio = (values[PosicionMedia]);
                        return valorMedio;
                    }
                }
            }
            return valorMedio ;
        }

        //Convertir el objeto en una linea de string
        public void ConvertValuesToString()
        {

        }

        /*
        public NodoM<T> InsertTree(NodoM<T> Actual, NodoM<T> Intermedio, T Nuevo)
        {
            if (Actual.Children.Count == 0)
            {
                if (Actual.Values.Count < grado - 1)
                {
                    Actual.Values.Add(Nuevo);
                    Actual.Values.Sort();

                    //Modificar Archivo
                    return Actual;
                }
                else
                {
                    Actual = SplitTree(Actual, Intermedio, Nuevo);
                }
            }
            else
            {
                int i;
                for (i = 0; i < Actual.Values.Count; i++)
                {
                    if (Nuevo.CompareTo(Actual.Values[i]) == -1)
                    {
                        Actual.Children[i] = InsertTree(Actual.Children[i], Children[i], Nuevo);
                    }
                }
                if (i == Actual.Values.Count)
                {
                    Actual.Children[i] = InsertTree(Actual.Children[i], Actual, Nuevo);
                }
            }
            return Actual;
        }

        public NodoM<T> SplitTree(NodoM<T> Actual, NodoM<T> Intermedio, T Nuevo)
        {
            if (Intermedio.Children.Count == 0)
            {
                NodoM<T> NodoS = new NodoM<T>(grado);
                for (int i = 0; i < Actual.Values.Count + 1; i++)
                {
                    if (i == Actual.Values.Count) NodoS.Values.Add(Nuevo);
                    else NodoS.Values.Add(Actual.Values[i]);
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
                    Nuevo1.Values.Add(ArregloM[i]);
                }

                //NodoAnterior
                NodoM<T> Anterior = new NodoM<T>(grado);
                Anterior.Id = Actual.Id;
                Anterior.Father = Nuevo1.Id + 1;
                for (int i = 0; i < posicion; i++)
                {
                    Anterior.Values.Add(NodoS.Values[i]);
                }

                //Raiz
                NodoM<T> Raiz = new NodoM<T>(grado);
                Raiz.Id = Convert.ToInt32(metadata[2]) + 1;
                for (int i = 0; i < ValorM.Count; i++)
                {
                    Raiz.Values.Add(ValorM[i]);
                }

                Raiz.Children.Add(Anterior);
                Raiz.Children.Add(Nuevo1);

                //Mandar la nueva informacion al archivo
                return Raiz;
            }
            else
            {
                Nodo<T> NodoS = new Nodo<T>(grado);
                NodoS.Values.AddRange(Actual.Values);
                NodoS.Values.Add(Nuevo);
                NodoS.Values.Sort();

                int posicion = (grado % 2 == 0) ? (grado / 2) - 1 : (grado - 1) / 2;
                var FileHandling = new FileHandling<T>();
                var metadata = FileHandling.Obtener_Metadata();
                var ArregloM = ArregloValoresMayores(NodoS.Values);
                var ValorM = ValorMedioS(NodoS.Values);

                //NodoNuevo
                NodoM<T> NodoMayores = new NodoM<T>(grado);
                NodoMayores.Id = Convert.ToInt32(metadata[2]);
                NodoMayores.Father = Convert.ToInt32(metadata[0]); //Preguntar si es la raiz
                NodoMayores.Values.AddRange(ArregloM);

                //NodoAnterior
                NodoM<T> Anterior = new NodoM<T>(grado);
                Anterior.Id = Actual.Id;
                Anterior.Father = NodoMayores.Id + 1;
                for (int X = 0; X < posicion; X++)
                {
                    Anterior.Values.Add(Actual.Values[X]);
                }


                //Obtener la raiz
                int i;

                if (Intermedio.Values.Count < grado - 1)
                {
                    for (i = 0; i < Intermedio.Values.Count; i++)
                    {
                        if (ValorM[0].CompareTo(Intermedio.Values[i]) == -1)
                        {


                        }
                    }

                }
                else
                {
                    SplitTree(Intermedio, Intermedio, Nuevo);
                }



            }
            return Actual;


        }

        */
    }
}

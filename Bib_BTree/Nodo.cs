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
        
        //Insert
        public void InsertTree(Nodo<T> nodo, T value)
        {
            //Obtener la raiz
            var FileHandling = new FileHandling<T>();
           
            if(nodo.Id == FileHandling.ID_Obtener_Raiz(nodo.Id))
            {
                
                //Si no tengo hijos
                if (nodo.Children.Count == 0)
                {
                    if (nodo.Values.Count < grado - 1)
                    {
                        nodo.Values.Add(value);
                        nodo.Values.Sort();
                    }
                    else
                    {
                        nodo.Values.Add(value);
                        nodo.Values.Sort();
                        SplitNode(nodo.Children,nodo.Values, nodo.Id);
                    }
                }
                else
                {
                    //ListaValores hijos
                    for (int i = 0; i < ListValues.Count; i++)
                    {
                        var ListValuesh = FileHandling.Obtener_Valores(ListChildre[i].ToString());

                            if (ListValues[i].CompareTo(value) == -1)
                            {
                                InsertTree(ListChildre[i].ToString(), value);
                            }
                            else
                            {
                                InsertTree(ListChildre[i].ToString(), value);
                            }

                    }
                }

            }
            
        }

        public void SplitNode(List<T> Children ,List<T> Values, int ID)
        {
            var FileHandling = new FileHandling<T>();
            
            var ArregloValoresM = ArregloValoresMayores(Values);
            var ValorMedio = ValorMedioS(Values);
            int posicion  = (grado % 2 == 0) ? (grado / 2) - 1 :  (grado - 1) / 2);

            if (Children.Count == 0)
            {
                //NodoDividio
                Nodo<T> NodeAnterior = new Nodo<T>(grado);
                NodeAnterior.Id = Convert.ToInt32(ID);
                for (int i = 0; i < posicion ; i++)
                {
                    NodeAnterior.Values.Add(Values[i]);
                    NodeAnterior.Children = Children;
                    
                }

                //NodoNuevo
                Nodo<T> NodeNuevo = new Nodo<T>(grado);
                var ProximoDisponible = FileHandling.Obtener_Metadata();
                NodeAnterior.Id = Convert.ToInt32(ProximoDisponible[2]);
                for (int i = posicion + 1; i < Values.Count; i++)
                {
                    NodeNuevo.Values.Add(Values[i]);
                    NodeNuevo.Children = Children;
                }

                //Raiz
                Nodo<T> NuevaRaiz = new Nodo<T>(grado);
                NuevaRaiz.Id = NodeNuevo.Id + 1;
                NuevaRaiz.Values.Add(ValorMedio);
                NuevaRaiz.Children.Add(NodeAnterior.Id);
                NuevaRaiz.Children.Add(NodeNuevo.Id);

            }
            else
            {

            }
          
        }

        */
    }
}

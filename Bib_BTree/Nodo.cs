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
        public List<string> Values { get; set; }
        public List<int> Children { get; set; }

        public int SizeNodoLenght => 5 * (grado - 1) + (grado * 5) + 4 + 4 + 5;

        public Nodo(int grado)
        {
            Values = new List<string>();
            Children = new List<int>();
            this.grado = grado;
        }

        public void Insert(T Value, string Id)
        {
            FileHandling fileHandling = new FileHandling();


            Children = fileHandling.Obtener_Hijos(Id);

            if (Children.Count == 0)
            {
                Values = fileHandling.Obtener_Valores(Id);

                if (Values.Count < grado - 1)
                {
                    Values.Add(Value.ToString());
                    Nodo<T> actual = new Nodo<T>(grado);
                    actual.Id = Convert.ToInt32(Id.Trim());
                    actual.Father = Convert.ToInt32(fileHandling.Obtener_Padre(Id));
                    actual.Values = Values;
                    actual.Values.Sort();
                    actual.Children = Children;

                }
                else
                {
                    List<string> ValuesSeparar = new List<string>();
                    ValuesSeparar = Values;
                    ValuesSeparar.Add(Value.ToString());
                    SplitNodo(ValuesSeparar);

                }

            }
            else
            {

            }

        }

        public void SplitNodo(List<string> values)
        {
            //grado par
            if (grado % 2 == 0)
            {
                var ValorMedio = "";
                var ArregloValoresPar = new List<string>();
                ArregloValoresPar = ArregloValoresMayoresPar(values);
                ValorMedio = ValorMedioPar(values);


            }
            else if (grado % 2 != 0)
            {

            }
        }

        public List<string> ArregloValoresMayoresPar(List<string> values)
        {
            var ValoresMinimos = (grado / 2) - 1;
            var ArregloValoresPar = new List<string>();
            for (int i = 0; i < ValoresMinimos; i++)
            {
                ArregloValoresPar.Add(values[(values.Count - 1) - i]);
            }
            return ArregloValoresPar;
        }

        public string ValorMedioPar(List<string> values)
        {
            var ValoresMinimos = (grado / 2) - 1;
            var valorMedio = "";
            int i;
            for (i = 0; i < ValoresMinimos + 1; i++)
            {
                if (i == ValoresMinimos)
                {
                    valorMedio = (values[(values.Count - 1) - i]);
                }
            }

            return valorMedio;
        }

    }
}

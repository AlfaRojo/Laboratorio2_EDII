using System;
using System.Collections.Generic;

namespace Bib_BTree
{
    public class NodoM<TKey, TNext> 
    {
        public int grado { get; set; }
        public int Id { get; set; }
        public int Father { get; set; }
        public List<Map<TKey, TNext>> Values { get; set; }
        public List<NodoM<TKey, TNext>> Children { get; set; }

        public NodoM(int grado)
        {
            Values = new List<Map<TKey, TNext>>();
            Children = new List<NodoM<TKey, TNext>>(grado);
            this.grado = grado;
        }

        
        public List<Map<TKey,TNext>> ArregloValoresMayores(List<Map<TKey, TNext>> values)
        {
            var ArregloValoresM = new List<Map<TKey, TNext>>();

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

        public List<Map<TKey, TNext>> ValorMedioS(List<Map<TKey, TNext>> values)
        {
            var valorMedio = new List<Map<TKey, TNext>>();

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

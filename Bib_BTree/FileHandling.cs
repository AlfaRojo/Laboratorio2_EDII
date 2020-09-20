using System;
using System.Collections.Generic;
using System.Text;

namespace Bib_BTree
{
    public class FileHandling 
    {
        /// <summary>
        /// Devuelve una lista con posiciones
        /// <root><father>
        /// <lastnode><lastnodeaviable>
        /// <MediuValue><ListValuesMax>
        /// </summary>
        /// <param name="root"></param>
        /// <param name="father"></param>
        /// <param name="lastNode"></param>
        /// <param name="lastAvNode"></param>
        /// <returns></returns>
        public List<string> CrearArchivo(string root, string father, int lastNode, int lastAvNode)
        {
            List<string> retorno = new List<string>();
            retorno.Add(root);
            retorno.Add(father);
            retorno.Add(lastNode.ToString());
            retorno.Add(lastAvNode.ToString());
            //Escribir
            return retorno;
        }

        public List<string> ListadoValoresMayores()
        {
            List<string> l = new List<string>();
            l.Add("0015");
            return l;
        }
        public string Obtener_Raiz()
        {
            string r = "0001";
            return r;
        }
        /// <summary>
        /// Lista[0] => Hijos menores
        /// Lista[1] => Hijos mayores
        /// </summary>
        /// <param name="father"></param>
        /// <returns></returns>
        public List<int> Obtener_Hijos(string father)
        {
            List<int> H = new List<int>();
            return H;
        }

        public List<string> Obtener_Valores(string father)
        {
            List<string> V = new List<string>();
            V.Add("0005");
            V.Add("0010");
            V.Add("0015");
            return V;
        }

        public string Obtener_Padre(string father)
        {
            string p = "-1";
            return p;
        }


    }
}


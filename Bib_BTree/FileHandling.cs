using System;
using System.Collections.Generic;
using System.Text;

namespace Bib_BTree
{
    class FileHandling
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
            
        }
        public List<string> Obtener_Raiz()
        { 
            
        }
        /// <summary>
        /// Lista[0] => Hijos menores
        /// Lista[1] => Hijos mayores
        /// </summary>
        /// <param name="father"></param>
        /// <returns></returns>
        public List<int> Obtener_Hijos(string father)
        { 
            
        }
    }
}

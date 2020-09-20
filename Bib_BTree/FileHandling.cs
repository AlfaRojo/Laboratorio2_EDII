using Bib_BTree.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bib_BTree
{
    public class FileHandling
    {
        /// <summary>
        /// 
        /// </summary>
        public void Crear_Archivo()
        {
            if (!File.Exists(Data.Instance.ruta))
            {
                string start = $"000{Data.grado.ToString("000;-000")}|0000|0001|";
                File.WriteAllText(Data.Instance.ruta, start);
            }
        }

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
        public List<string> Metadata(string root, string father, int lastNode, int lastAvNode)
        {
            List<string> retorno = new List<string>();
            retorno.Add(root);
            retorno.Add(father);
            retorno.Add(lastNode.ToString());
            retorno.Add(lastAvNode.ToString());
            using (var file = new FileStream(Data.Instance.ruta, FileMode.OpenOrCreate))
            {
                foreach (var item in retorno)
                {

                }
            }
            return retorno;
        }
        //public List<string> ListadoValoresMayores()
        //{ 
            
        //}
        //public List<string> Obtener_Raiz()
        //{ 
            
        //}
        ///// <summary>
        ///// Lista[0] => Hijos menores
        ///// Lista[1] => Hijos mayores
        ///// </summary>
        ///// <param name="father"></param>
        ///// <returns></returns>
        //public List<int> Obtener_Hijos(string father)
        //{ 
            
        //}
    }
}

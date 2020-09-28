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
        /// Se realiza la creación del archivo en la ruta del proyecto
        /// </summary>
        public void Crear_Archivo()
        {
            if (!File.Exists(Data.Instance.ruta))
            {
                string start = $"000{Data.grado.ToString("000;-000")}|0000|0001|";
                File.WriteAllText(Data.Instance.ruta, start);
            }
        }
        public List<string> getMetadata()
        {
            var linea = string.Empty;
            using (var file = new StreamReader(Data.Instance.ruta))
            {
                linea = file.ReadLine();
            }
            List<string> retorno = new List<string>();
            retorno.AddRange(linea.Split('|'));
            return retorno;
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
            string archivado = string.Empty;
            foreach (var item in retorno)
            {
                archivado += item;
            }
            using (StreamWriter outfile = new StreamWriter(Data.Instance.ruta))
            {
                outfile.WriteLine(archivado);
            }
            return retorno;
        }

        /// <summary>
        /// Se recibe un nodo que compara IDs para ingresar al archivo
        /// </summary>
        //public void Ingresar_Informacion(Nodo<T> node)
        //{
        //    using (StreamWriter outfile = new StreamWriter(Data.Instance.ruta))
        //    {
        //        using (StreamReader lectura = new StreamReader(Data.Instance.ruta))
        //        {
        //            while (lectura.Peek() > -1)
        //            {
        //                string linea = lectura.ReadLine();
        //                if (!String.IsNullOrEmpty(linea))
        //                {
                           

        //                }
        //            }
        //        }
        //    }
        //}


        public int ID_Obtener_Raiz(int Father)
        {
            int r = 1;
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

        public List<string> Obtener_Metadata()
        {
            List<string> M = new List<string>();
            M.Add("0001");
            M.Add("0000");
            M.Add("0002");
            return M; 
        }
    }
}


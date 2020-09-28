using Bib_BTree.Models;
using System.Collections.Generic;

namespace Bib_BTree.Helper
{
    public class Data
    {
        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null) _instance = new Data();
                return _instance;
            }
        }
        //Add structures
        public static int grado;
        public string ruta;
        public ArbolB<int, Movie> temp = new ArbolB<int, Movie>(Data.grado);
        public List<string> arbol_Temp = new List<string>();
    }
}

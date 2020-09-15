using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_BTree.Helper
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
        public List<string> arbol_Temp = new List<string>();
    }
}

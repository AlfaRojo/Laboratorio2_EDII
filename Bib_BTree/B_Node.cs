using System;
using System.Collections.Generic;

namespace Bib_BTree
{
    class B_Node<T> where T : IComparable
    {
        public int grado { get; set; }
        public int Id { get; set; }
        public int Father { get; set; }
        public B_Node<T> root { get; set; }
        public List<T> Values { get; set; }
        public List<B_Node<T>> Children { get; set; }

        public B_Node(int grado)
        {
            Values = new List<T>();
            Children = new List<B_Node<T>>(grado);
            this.grado = grado;
        }

        public void Insert(T Value)
        {
            B_Node<T> new_Node = new B_Node<T>(grado);
            if (root == null)
            {
                new_Node.Values.Add(Value);
                new_Node.Id = 1;
            }
            else
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bib_BTree
{
    public class BEntry<TKey, T> : IEquatable<BEntry<TKey, T>>
    {
        public TKey LLave { get; set; }

        public T Apuntador { get; set; }
        // Comparador de llaves y apuntadores
        public bool Equals(BEntry<TKey, T> other)
        {
            return this.LLave.Equals(other.LLave) && this.Apuntador.Equals(other.Apuntador);
        }
    }
}

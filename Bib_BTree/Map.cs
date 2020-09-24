using System;
using System.Collections.Generic;

namespace Bib_BTree
{
    public class Map<TKey, TNext> : IEquatable<Map<TKey, TNext>>
    {

        public TKey Value { get; set; }
        public TNext Next { get; set; }

        public bool Equals(Map<TKey, TNext> other)
        {
            return this.Value.Equals(other.Value) && this.Next.Equals(other.Next);  
        }
    }
}

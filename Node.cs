using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Node<T>
    {
        public char Symbol { get; set; }
        public Dictionary<char, Node<T>> SubNode { get; set; }
        public T Data { get; set; }
        public bool isWord { get; set; }
        public string Prefix { get; set; }

        public Node(char symb, T data, string prefix)
        {
            Symbol = symb;
            Data = data;
            Prefix = prefix;
            SubNode = new Dictionary<char, Node<T>>();
        }

        public override string ToString()
        {
            return $"[{Symbol}] [{Data}] [{Prefix}]";
        }

        public Node<T> TryFind(char symb)
        {
            if (SubNode.TryGetValue(symb, out Node<T> value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

    }
}

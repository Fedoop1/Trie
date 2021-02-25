using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Trie<T>
    {
        Node<T> Root;


        public Trie()
        {
            Root = new Node<T>('\0', default(T), string.Empty);
        }

        public void Add(string Key, T Data)
        {
            AddNode(Key, Data, Root);
        }

        private void AddNode(string Key, T Data, Node<T> Root)
        {
            if(string.IsNullOrEmpty(Key))
            {
                if(!Root.isWord)
                {
                    Root.isWord = true;
                    Root.Data = Data;
                }
            }
            else
            {
                char symb = Key[0];
                var subNode = Root.TryFind(symb);

                if(subNode != null)
                {
                    AddNode(Key.Substring(1), Data, subNode);
                }
                else
                {
                    Node<T> newNode = new Node<T>(symb, Data, Root.Prefix + symb);
                    Root.SubNode.Add(symb, newNode);
                    AddNode(Key.Substring(1), Data, newNode);
                }
            }
        }

        public void Remove(string Key)
        {
            RemoveNode(Key, Root);
        }

        private void RemoveNode(string Key, Node<T> Root)
        {
            if(string.IsNullOrEmpty(Key))
            {
                if(Root.isWord)
                {
                    Root.isWord = false;
                    Root.Data = default(T);
                }
            }
            else
            {
                var subNode = Root.TryFind(Key[0]);
                if(subNode != null)
                {
                    RemoveNode(Key.Substring(1), subNode);
                }
            }
        }

        public bool Search(string Key, out T value)
        {
            return SearchNode(Key, Root, out value);
        }

        private bool SearchNode(string Key, Node<T> Root, out T value)
        {
            var result = false;
            value = default(T);

            if(string.IsNullOrEmpty(Key))
            {
                if(Root.isWord)
                {
                    result = true;
                    value = Root.Data;
                }
            }
            else
            {
                var subNode = Root.TryFind(Key[0]);
                if (subNode != null)
                {
                    result = SearchNode(Key.Substring(1), subNode, out value);
                }
            }

            return result;
        }
    }
}

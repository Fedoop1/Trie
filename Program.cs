using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie<int> trie = new Trie<int>();

            trie.Add("Привет", 1000);
            trie.Add("Приём", 150);
            trie.Add("Пакет", 250);
            trie.Add("Арбуз", 550);
            trie.Add("Арбат", 150);
            trie.Add("Орбита", 550);
            trie.Add("Артас", 550);

            TrySearch(trie, "Привет");
            TrySearch(trie, "Орбита");
            TrySearch(trie, "Артас");

            trie.Remove("Орбита");
            TrySearch(trie, "Орбита");
            TrySearch(trie, "Никита");

            Console.ReadLine();
        }
        private static void TrySearch(Trie<int> Trie, string word)
        {
            if(Trie.Search(word, out int value))
            {
                Console.WriteLine($"Word = [{word}]. Value = [{value}].");
            }
            else
            {
                Console.WriteLine($"Word = [{word}] do not found.");
            }
        }
    }
}

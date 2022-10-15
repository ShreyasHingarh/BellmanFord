using System;

namespace BellmanFord 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BellmanFordStuff<string> ford = new BellmanFordStuff<string>();
            ford.AddVertex("A");
            ford.AddVertex("B");
            ford.AddVertex("C");
            ford.AddVertex("D");
            ford.AddVertex("E");
            ford.AddVertex("F");
            ford.AddVertex("G");
            ford.AddVertex("H");
            ford.AddVertex("I");

            ford.AddEdge(ford.FindVertex("D"), ford.FindVertex("F"), 8);
            ford.AddEdge(ford.FindVertex("D"), ford.FindVertex("H"), 2);
            ford.AddEdge(ford.FindVertex("D"), ford.FindVertex("G"), 11);
            ford.AddEdge(ford.FindVertex("H"), ford.FindVertex("B"), 16);
            ford.AddEdge(ford.FindVertex("B"), ford.FindVertex("G"), 9);
            ford.AddEdge(ford.FindVertex("G"), ford.FindVertex("E"), 8);
            ford.AddEdge(ford.FindVertex("E"), ford.FindVertex("A"), 19);
            ford.AddEdge(ford.FindVertex("A"), ford.FindVertex("I"), -10);
            ford.AddEdge(ford.FindVertex("I"), ford.FindVertex("C"), -7);
            ford.AddEdge(ford.FindVertex("C"), ford.FindVertex("A"), -5);
            ford.AddEdge(ford.FindVertex("A"), ford.FindVertex("B"), 3);
            ford.AddEdge(ford.FindVertex("F"), ford.FindVertex("A"), 15);

            List<Vertex<string>> vertices = ford.BellmanFord();
            foreach(var a in vertices)
            {
                Console.WriteLine(a.Value);
            }
            

        }
    }
}
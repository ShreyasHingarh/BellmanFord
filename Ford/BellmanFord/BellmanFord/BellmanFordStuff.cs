using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord
{
    public class Vertex<T>
    {
        public T Value;
        public float CumulativeDistance;
        public Vertex<T> Founder;
        public bool hasBeenVisited;
        public List<Edge<T>> Neighbors;
        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Edge<T>>();
            CumulativeDistance = float.PositiveInfinity;
            Founder = null;
            hasBeenVisited = false;
        }
    }
    public class Edge<T>
    {
        public Vertex<T> A;
        public Vertex<T> B;
        public float Weight;
        public Edge(Vertex<T> a, Vertex<T> b, float weight)
        {
            A = a;
            B = b;
            Weight = weight;
        }
            
    }
    public class GraphFunctions<T>
    {
        public List<Vertex<T>> Vertices;
        public List<Edge<T>> Edges;
        public GraphFunctions()
        {
            Vertices = new List<Vertex<T>>();
            Edges = new List<Edge<T>>();
        }
        public void AddVertex(T value)
        {
            if (value == null) return;
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].Value.Equals(value)) return;
            }
            Vertices.Add(new Vertex<T>(value));
        }
        public void AddEdge(Vertex<T> a, Vertex<T> b,float weight)
        {
            if (a == b || a == null || b == null || weight == null) return;
            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].A == a && Edges[i].B == b) return;
            }
            Edges.Add(new Edge<T>(a, b, weight));
            a.Neighbors.Add(Edges[Edges.Count - 1]);
        }
        public Vertex<T> FindVertex(T value)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].Value.Equals(value))
                {
                    return Vertices[i];
                }
            }
            return null;
        }
        public Edge<T> FindEdge(Vertex<T> a, Vertex<T> b)
        {
            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].A == a && Edges[i].B == b) return Edges[i];
            }
            return null;
        }

    }

    internal class BellmanFordStuff<T> : GraphFunctions<T>
    {
        public List<Vertex<T>> BellmanFord()
        {
            Queue<Vertex<T>> vertices = new Queue<Vertex<T>>();
            List<Vertex<T>> verticiesVisited = new List<Vertex<T>>();
            foreach(var vertex in Vertices)
            {
                vertices.Enqueue(vertex);
            }
            while(vertices.Count > 0)
            {
                Vertex<T> Current = vertices.Dequeue();
                if (!verticiesVisited.Contains(Current)) verticiesVisited.Add(Current); 
                foreach (var vertex in Vertices)
                {
                    vertex.CumulativeDistance = float.PositiveInfinity;
                    vertex.Founder = null;
                }
                Current.CumulativeDistance = 0;
                foreach (var vertex in Vertices)
                {
                    foreach (var neighbor in vertex.Neighbors)
                    {
                        float tentativeDistance = Current.CumulativeDistance + neighbor.Weight;
                        if (tentativeDistance < Current.CumulativeDistance)
                        {
                            neighbor.B.CumulativeDistance = tentativeDistance;
                            neighbor.B.Founder = vertex;
                            if (!verticiesVisited.Contains(neighbor.B)) verticiesVisited.Add(neighbor.B);
                        }
                    }
                }
                foreach (var edge in Edges)
                {
                    float tentativeDistance = edge.B.CumulativeDistance + edge.Weight;
                    if (edge.B.CumulativeDistance > tentativeDistance)
                    {
                        verticiesVisited.Remove(edge.A);
                    }
                }
            }
            return verticiesVisited;

        }
    }
}

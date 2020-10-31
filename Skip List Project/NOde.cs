using System;
using System.Collections.Generic;
using System.Text;

namespace Skip_List_Project
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Neighbors { get; set; }

        public int Height
        {
            get
            {
                return Neighbors.Count;
            }
        }

        public Node<T> this[int index]
        {
            get
            {
                return Neighbors[index];
            }
            set
            {
                Neighbors[index] = value;
            }
        }
        
        public Node(int height = 1)
        {
            Neighbors = new List<Node<T>>(height);
        }

        public Node(T val, int height) : this(height)
        {
            Value = val;
        }

        public void Increment()
        {
            Neighbors.Add(default);
        }
    }
}

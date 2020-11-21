using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Transactions;

namespace Skip_List_Project
{
    public class SkipList<T> : ICollection<T>
        where T : IComparable<T>        
    {
        private int count;
        public int Count => count;
        public bool IsReadOnly => false;

        Node<T> head;

        public SkipList()
        {
            count = 0;
            head = new Node<T>(1);
        }


        //Randomly chooses the height for each node
        private int ChooseRandomHeight()
        {
            Random gen = new Random();
            int newHeight = 1;

            while (newHeight < head.Height + 1 && gen.Next(1, 3) == 1)
            {
                newHeight++; 
            }

            if (newHeight > head.Height)
            {
                head.Increment(); 
            }

            return newHeight;
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value, ChooseRandomHeight());

            Node<T> cur = head;

            int a = cur.Height - 1;

            while (a >= 0)
            {
                int compare;
                if (cur[a] == null)
                {
                    compare = 1;
                }
                else
                {
                    compare = cur[a].Value.CompareTo(value);
                }

                if (compare > 0)
                {
                    if (newNode.Height > a)
                    {
                        newNode[a] = cur[a];
                        cur[a] = newNode;
                    }
                    a--;
                }
                else
                {
                    cur = cur[a]; 
                }
            }

            count++; 
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Remove(T value)
        {
            int level = head.Height - 1;
            Node<T> node = head;
            bool removed = false;

            while (level >= 0)
            {
                int comparison;
                if (node[level] == null)
                {
                    comparison = 1;
                }
                else
                {
                    comparison = node[level].Value.CompareTo(value); 
                }

                if (comparison < 0)
                {
                    node = node[level];
                }
                else if (comparison > 0)
                {
                    level--;
                }
                else //if they are equal
                {
                    removed = true;
                    node[level] = node[level][level]; //skips over the node to remove
                    level--;
                }
            }

            if (removed)
            {
                count--;    
            }

            return removed;
        }

        public bool Contains(T item)
        {
            Node<T> node = head;
            int level = head.Height - 1;

            while (level >= 0)
            {
                int comparison;
                if (node[level] == null)
                {
                    comparison = 1;
                }
                else
                {
                    comparison = node[level].Value.CompareTo(item);
                }

                if (comparison == 0)
                {
                    return true; 
                }
                else if (comparison < 0)
                {
                    node = node[level];
                }
                else
                {
                    level--;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex > Count) // not enough space
            {
                throw new Exception("Not nuff space");
            }


            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }

            //Node<T> node = head;

            //while (node[0].Value != null)//while the bottom node has a next
            //{
            //    array[arrayIndex] = node.Value;
            //    node = node[0];
            //    arrayIndex++;
            //}
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> cur = head;
            while (cur[0] != null)
            {
                yield return cur[0].Value;
                cur = cur[0];
            }
        }    

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

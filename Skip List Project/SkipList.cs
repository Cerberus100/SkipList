﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text;

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
            head = new Node<T>();
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

            int a = cur.Height;

            while (a >= 0)
            {
                int compare = newNode.Value.CompareTo(cur.Value); //im pretty sure this is wrong
                
                //TODO: finish learning how to search through. Then finish add. 


            }

            count++; 
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }    

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
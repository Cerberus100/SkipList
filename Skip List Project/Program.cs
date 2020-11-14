using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Skip_List_Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new SkipList<int>();

            list.Add(5);
            list.Add(10);
            list.Add(15);

            bool thing = list.Contains(0);


            foreach (int value in list)
            {
                Console.WriteLine(value);
            }
        }
    }
}

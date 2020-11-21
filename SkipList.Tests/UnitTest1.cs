using System;
using Skip_List_Project;
using Xunit;
using System.Linq;

namespace SkipList.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(50000)]    
        public void AddWorksWithNormal (int count)
        {
            int max = 0;
            Random gen = new Random();

            var list = new SkipList<int>(); 

            for (int a = 0; a < count; a++)
            {
                int added = gen.Next(1, 1000);
                list.Add(added);
                max = Math.Max(max, added); 
            }

            Assert.Equal(list.Count, count);
            Assert.True(list.Contains (max));
        }

        [Theory]
        [InlineData(4, 100)]
        [InlineData(5, 1000)]
        [InlineData(7, 10000)]
        [InlineData(100, 20000)]
        public void RemoveWorksWithNormalCases (int num, int count)
        {
            var list = new SkipList<int>();

            for (int a = 1; a <= count; a++)
            {
                list.Add(a);
            }

            list.Remove(num);

            Assert.False(list.Contains (num));
            Assert.Equal(list.Count, count-1);
        }

        [Theory]
        [InlineData(13, 100)]
        [InlineData(123, 1000)]
        [InlineData(2354, 10000)]
        [InlineData(4344, 20000)]
        public void SearchingWithNormalCases(int num, int count)
        {
            var list = new SkipList<int>();

            for (int a = 1; a <= count; a++)
            {
                list.Add(a);
            }

            Assert.True(list.Contains (num));
        }

        [Theory]
        [InlineData(4, 10000)]
        [InlineData(1000, 10000)]
        [InlineData(10000, 25000)]
        [InlineData(25000, 9999)]
        public void EnumeratingForLargeCases (int num, int max)
        {
            var list = new SkipList<int>();
            Random gen = new Random();

            for (int a = 0; a < num; a++)
            {
                list.Add(gen.Next (1, max));
            }

            var arr = list.ToArray();

            Assert.Equal(list.Count, arr.Length);
        }
    }
}

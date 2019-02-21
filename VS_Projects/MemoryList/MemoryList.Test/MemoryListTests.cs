using ML.Library;
using System;
using Xunit;

/* 
 write some tests for that class before you write the methods you are testing.
the memorylist will support many or (if you're ambitious) all the behavior of List
and also a method `bool HasEverContained(T value)` which will check if a given value as ever been in the list in the past.
try to implement index `[]` operator overloading
 */

namespace ML.Test
{
    public class MemoryListTests
    {
        // second type of xUnit test" Theory
        // Facts don't allow params
        // theoreies accepts sets of params, to run the test against all of them
        // testing Add function
        [Theory]
        [InlineData(-5)]
        [InlineData(10)]
        [InlineData(10000)]
        public void AddedItemsShouldBeContained(int value)
        {
            var list = new MemoryList<int>();
            list.Add(value);
            Assert.True(list.Contains(value));

        }

        // testin Contains function
        [Theory]
        [InlineData(-5)]
        [InlineData(10)]
        [InlineData(10000)]
        public void ContainsShouldBeTrueForContained(int value)
        {
            // arrange
            var memoryList = new MemoryList<int>();

            if(value > 0)
            {
                memoryList.Add(value);
            }

            // act
            var result = memoryList.Contains(value);

            // assert
            Assert.True(result);
        }

        // Testin Remove function
        [Theory]
        [InlineData(10)]
        [InlineData(10000)]
        public void RemoveShouldRemoveVariable(int value)
        {
            // arrange
            var memoryList = new MemoryList<int>();

            //act
            memoryList.Add(-5);
            memoryList.Add(10);
            memoryList.Add(10000);
            memoryList.Remove(value);

            // assert
            Assert.False(memoryList.Contains(value));

        }

        // Testin Remove function
        [Theory]
        [InlineData(-5)]
        [InlineData(10)]
        [InlineData(10000)]
        public void ContainsShouldBeTrueIfValueEverContained(int value)
        {
            // arrange
            var memoryList = new MemoryList<int>();

            //act
            memoryList.Add(-5);
            memoryList.Add(10);
            memoryList.Remove(10);

            // assert
            Assert.True(memoryList.HasEverContained(value));


            // act
            var result = memoryList.Contains(value);

            // assert
            Assert.False(memoryList.Contains(value));
        }
    }
}

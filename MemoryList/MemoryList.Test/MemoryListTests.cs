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
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(10000)]
        public void AddedItemsShouldBeContained(int value)
        {
            var list = new MemoryList<int>();
            list.Add(value);
            Assert.True(list.Contains(value));

        }

        //[Fact]
        //public void AddShouldNotThrowAnException
    }
}

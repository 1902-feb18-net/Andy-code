using System;
using Xunit;
using CollectionTesting.Library;

namespace CollectionTesting.Test
{
    // usually write one test class to write one of our real classes
    public class MyStringCollectionTest
    {
        [Fact]
        public void Test1()
        {
            // testing in general... make sure the code does what we expect
            // manual testing... run the code in IDEs and plug in diff inputs
            // and make sure we get expected output

            // automated testing ... we write the instructions for a test and the
            //expected results, then we re-run lots of tests automatically

            // this helps us find and solve bugs quicker for subsequent development
            // helps us design well in the first place
            // testable code is better designed code

            // unit testing is a particular kind of automated testing,
            // where we resolve to test the smallest pieces we can at a time

            // the alternative would be integration testing 
            //
        }

        // FactAttribute is our 1st example of a c# attribute
        [Fact]
        //put our test methods inside an otherwise ordinary class
        public void AddShouldNotThrowException()
        {
            // three general steps to unit test
            // 1. arrange
            var collection = new MyStringCollection();

            // 2. act
            collection.Add("abc");
            // if an exception is thrown, that's caught by the test runner and counted
            // as a failure of the test

            // 3. assert
            // none needed here
        }

        [Fact]
        public void ContainsShouldBeTrueOrContained()
        {
            //arrange
            var collection = new MyStringCollection();
            collection.Add("asdf");

            //act
            var result = collection.Contains("asdf");

            //assert
            Assert.True(result);
        }

        [Fact]
        public void ContainsShouldBeFalseForNotContained()
        {
            //arrange
            var collection = new MyStringCollectionTest();
            collection.Add("asdf");

            //act
            var result = collection.Contains("asdf");

            //assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveEmptyShouldRemoveOneEmpty()
        {
            //sometimes we call the obj thats being tested
            // the subject under test (SUT)

            //arrange
            var sut = new MyStringCollection();
            sut.Add("");

            // act
            sut.RemoveEmpty();

            //assert
            Assert.False(sut.Contains(""));
        }

        [Fact]
        public void GetFirstShouldGetFirstFromNonEmptyList()
        {
            var sut = new MyStringCollection();
            sut.Add("asdf");
            sut.Add("fasd");

            var result = sut.GetFirst();

            // expected then actual
            Assert.Equal("asdf", result);
        }

        [Fact]
        public void GetFirstShouldThrowOnEmptyList()
        {
            var sut = new MyStringCollection();
            //    try
            //    {
            //        var result = sut.GetFirst();
            //    }
            //    catch (InvalidOperationException e)
            //    {
            //        return;
            //    }
            //    Assert.True(false, "should have thrown InvalidOperationException");
            //}

            // assertion succeeds if the right exception was thrown 
            // fails if not thrown
            Assert.ThrowsAny<InvalidOperationException>(() => sut.GetFirst());
        }
    }
}

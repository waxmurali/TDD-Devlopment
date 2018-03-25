using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sample
{
    [TestFixture]
    public class TestBinaryChop
    {
        [Test]
        public void Given_A_NumberFromList_Find_The_Index_Position() 
        {
            //Arrange
            var expectedPosition = 2;
            var binChop = new BinaryChop();
            var findNumber = 8;
            var listOfBinary = new List<int>(){21,3,8,4,6,9};

            //Act
            var actualResult = binChop.Chop(findNumber, listOfBinary.ToArray());

            //Assert
            Assert.AreEqual(expectedPosition,actualResult,"Expected position is not same as actual position returned");
        }

        [Test]
        public void Given_A_Number_ThatisNotinList_ShouldReturn_MinusOne()
        {
            //Arrange
            var expectedPosition = -1;
            var binChop = new BinaryChop();
            var findNumber = 23;
            var listOfBinary = new List<int>() { 21, 3, 8, 4, 6, 9 };

            //Act
            var actualResult = binChop.Chop(findNumber, listOfBinary.ToArray());

            //Assert
            Assert.AreEqual(expectedPosition, actualResult, "Expected position is not same as actual position returned");
        }


        [Test]
        public void Given_A_Number_InList_ShouldReturn_Position_Ten()
        {
            //Arrange
            var expectedPosition = 10;
            var binChop = new BinaryChop();
            var findNumber = 89;
            var listOfBinary = new List<int>() { 21, 3, 8, 4, 6, 9,45,12,134,67,89,90,12,46,456777,233,65,788,55 };

            //Act
            var actualResult = binChop.Chop(findNumber, listOfBinary.ToArray());

            //Assert
            Assert.AreEqual(expectedPosition, actualResult, "Expected position is not same as actual position returned");
        }

        [Test]
        public void Given_A_Number_InList_ShouldReturn_Position_Zero()
        {
            //Arrange
            var expectedPosition = 0;
            var binChop = new BinaryChop();
            var findNumber = 21;
            var listOfBinary = new List<int>() { 21, 3, 8, 4, 6, 9, 45, 12, 134, 67, 89, 90, 12, 46, 456777, 233, 65, 788, 55 };

            //Act
            var actualResult = binChop.Chop(findNumber, listOfBinary.ToArray());

            //Assert
            Assert.AreEqual(expectedPosition, actualResult, "Expected position is not same as actual position returned");
        }
    }

    


    public class BinaryChop
    {
        public int Chop(int findNumber, int[] listOfBinary)
        {
            for (var i = 0; i < listOfBinary.Length; i++)
            {
                if (listOfBinary[i] == findNumber)
                    return i;
            }

            return -1;

            //Convert to list and find the index
            //return listOfBinary.FindIndex(l => l == findNumber);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestClass()]
    public class RomanNumberTests
    {

        [TestMethod()]
        public void RomanNumberTest()
        {
            RomanNumber value = new RomanNumber(10);
            string result = "X";

            Assert.AreEqual(result, value.ToString());
        }
        

        [TestMethod()]
        public void AddTest()
        {
            RomanNumber one = new RomanNumber(10);
            RomanNumber two = new RomanNumber(20);
            RomanNumber result = new RomanNumber(30);

            RomanNumber factResult = one + two;
            
            Assert.AreEqual(factResult.ToString(),result.ToString());
        }

        [TestMethod()]
        public void AddMaxTest()
        {
            RomanNumber one = new RomanNumber(65500);
            RomanNumber two = new RomanNumber(40);

            Assert.ThrowsException<RomanNumberException>(() => one+two);
        }

        [TestMethod()]
        public void SubTest()
        {
            RomanNumber one = new RomanNumber(20);
            RomanNumber two = new RomanNumber(10);
            RomanNumber result = new RomanNumber(10);

            RomanNumber factResult = one - two;

            Assert.AreEqual(factResult.ToString(), result.ToString());
        }

        [TestMethod()]
        public void SubMinTest()
        {
            RomanNumber one = new RomanNumber(10);
            RomanNumber two = new RomanNumber(40);

            Assert.ThrowsException<RomanNumberException>(() => one - two);
        }

        [TestMethod()]
        public void MulTest()
        {
            RomanNumber one = new RomanNumber(20);
            RomanNumber two = new RomanNumber(10);
            RomanNumber result = new RomanNumber(200);

            RomanNumber factResult = one * two;

            Assert.AreEqual(factResult.ToString(), result.ToString());
        }

        [TestMethod()]
        public void MulMaxTest()
        {
            RomanNumber one = new RomanNumber(65000);
            RomanNumber two = new RomanNumber(2);

            Assert.ThrowsException<RomanNumberException>(() => one * two);
        }

        [TestMethod()]
        public void DivTest()
        {
            RomanNumber one = new RomanNumber(20);
            RomanNumber two = new RomanNumber(10);
            RomanNumber result = new RomanNumber(2);

            RomanNumber factResult = one / two;

            Assert.AreEqual(factResult.ToString(), result.ToString());
        }

        [TestMethod()]
        public void DivNULLTest()
        {
            RomanNumber one = new RomanNumber(35);
            RomanNumber two = new RomanNumber(0);

            Assert.ThrowsException<RomanNumberException>(() => one / two);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            RomanNumber value = new RomanNumber(652);
            string result = "DCLII";

            Assert.AreEqual(result, value.ToString());
        }

        [TestMethod()]
        public void ToStringNULLTest()
        {
            RomanNumber value = new RomanNumber(0);
            string result = "";

            Assert.AreEqual(result, value.ToString());
        }

        [TestMethod()]
        public void ToStringMaxTest()
        {
            RomanNumber value = new RomanNumber(65535);
            string result = "_L_X_VDXXXV";

            Assert.AreEqual(result, value.ToString());
        }

        [TestMethod()]
        public void CloneEqualTest()
        {
            RomanNumber one = new RomanNumber(5);
            RomanNumber two = new RomanNumber(666);
            one = two;

            Assert.AreEqual(one, two);
        }
        

        [TestMethod()]
        public void CompareToTest()
        {
            RomanNumber[] A = {
                new RomanNumber(5),
                new RomanNumber(6),
                new RomanNumber(2),
                new RomanNumber(184),
                new RomanNumber(1)
            };

            RomanNumber[] Result = {
                new RomanNumber(1),
                new RomanNumber(2),
                new RomanNumber(5),
                new RomanNumber(6),
                new RomanNumber(184)
            };
            Array.Sort(A);
            for(int i = 0; i < A.Length; i++)
            {
                Assert.AreEqual(A[i].ToString(), Result[i].ToString());
            }
        }
    }
}
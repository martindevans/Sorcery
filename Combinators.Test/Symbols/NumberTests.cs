using System.Numerics;
using Combinators.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Combinators.Test.Symbols
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void Number_Equals_Number()
        {
            Number a = new Number(1);
            Number b = new Number(1);

            Assert.IsTrue(a.Equals((object)b));
        }

        [TestMethod]
        public void Number_Does_Not_Equal_Different_Number()
        {
            Number a = new Number(1);
            Number b = new Number(2);

            Assert.IsFalse(a.Equals((object)b));
        }

        [TestMethod]
        public void Number_Does_Not_Equal_Object()
        {
            Number a = new Number(1);

            Assert.IsFalse(a.Equals(new object()));
        }

        [TestMethod]
        public void Number_GetHashCode_Consistently_Hashes()
        {
            Number a = new Number(1);
            Number b = new Number(1);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void Number_ToString_Mentions_Number()
        {
            BigInteger n = new BigInteger(new byte[] {234, 123, 251, 124, 132, 123, 12, 32, 214, 12, 31, 124, 5, 12, 3, 129});
            Number a = new Number(n);

            Assert.IsTrue(a.ToString().Contains(n.ToString()));
        }
    }
}

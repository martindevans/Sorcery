using Combinators.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Combinators.Test.Symbols
{
    [TestClass]
    public class BooleanTests
    {
        [TestMethod]
        public void Boolean_Equals_Boolean()
        {
            Boolean a = new Boolean(true);
            Boolean b = new Boolean(true);

            Assert.IsTrue(a.Equals((object)b));
        }

        [TestMethod]
        public void Boolean_Does_Not_Equal_Different_Boolean()
        {
            Boolean a = new Boolean(false);
            Boolean b = new Boolean(true);

            Assert.IsFalse(a.Equals((object)b));
        }

        [TestMethod]
        public void Boolean_Does_Not_Equal_Object()
        {
            Boolean a = new Boolean(false);

            Assert.IsFalse(a.Equals(new object()));
        }

        [TestMethod]
        public void Boolean_GetHashCode_Consistently_Hashes()
        {
            Boolean a = new Boolean(true);
            Boolean b = new Boolean(true);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void Boolean_ToString_Mentions_Boolean()
        {
            const bool B = true;
            Boolean a = new Boolean(B);

            Assert.IsTrue(a.ToString().Contains(B.ToString()));
        }
    }
}

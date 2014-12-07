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
    }
}

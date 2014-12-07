using System.Linq;
using Combinators.Machines;
using Combinators.Symbols;
using Combinators.Symbols.Combinators.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Combinators.Test.Symbols.Combinators.Arithmetic
{
    [TestClass]
    public class DecrementTests
    {
        readonly IMachine _machine = new StackMachine();

        [TestMethod]
        public void Decrement_2_Produces_1()
        {
            _machine.Push(2);
            _machine.Push<Decrement>();

            Assert.IsTrue(_machine.Reduce());
            Assert.IsFalse(_machine.Reduce());

            Assert.AreEqual(new Number(1), _machine.Symbols.Single());
        }

        [TestMethod]
        public void Decrement_0_Produces_0()
        {
            _machine.Push(0);
            _machine.Push<Decrement>();

            Assert.IsTrue(_machine.Reduce());
            Assert.IsFalse(_machine.Reduce());

            Assert.AreEqual(new Number(0), _machine.Symbols.Single());
        }
    }
}

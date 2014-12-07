using Combinators.Machines;
using Combinators.Symbols;
using Combinators.Symbols.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Combinators.Test.Symbols.Arithmetic
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

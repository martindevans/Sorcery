using System.Linq;
using Combinators.Machines;
using Combinators.Symbols;
using Combinators.Symbols.Combinators.Arithmetic;
using Combinators.Symbols.Combinators.SKI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Combinators.Test.Symbols.Combinators.SKI
{
    [TestClass]
    public class SKITests
    {
        private readonly StackMachine _machine = new StackMachine(); 

        [TestMethod]
        public void I_Returns_X()
        {
            _machine.Push(1);
            _machine.Push(new I());

            Assert.IsTrue(_machine.Reduce());
            Assert.IsFalse(_machine.Reduce());

            Assert.AreEqual(new Number(1), _machine.Symbols.Single());
        }

        [TestMethod]
        public void K_Returns_X()
        {
            _machine.Push(1);
            _machine.Push(2);
            _machine.Push(new K());

            Assert.IsTrue(_machine.Reduce());
            Assert.IsTrue(_machine.Reduce());
            Assert.IsFalse(_machine.Reduce());

            Assert.AreEqual(new Number(2), _machine.Symbols.Single());
        }

        [TestMethod]
        public void S_Applies_XZ_To_YZ()
        {
            _machine.Push(1);           // Z
            _machine.Push<Increment>(); // Y
            _machine.Push<Add>();       // X

            _machine.Push<S>();

            // This is a bit weird, better explain it!
            // S = xz(yz)
            // X = Add
            // Y = Increment
            // Z = 1
            //  yz = Increment 1 = 2
            //  xz = Add 1 = Partially applied add function
            //  (xz)(yz) = (Add 1)(2) = Add 1 2 = 3

            _machine.Reduce();
            _machine.Reduce();
            _machine.Reduce();
            _machine.Reduce();

            Assert.AreEqual(new Number(3), _machine.Symbols.Single());
        }
    }
}

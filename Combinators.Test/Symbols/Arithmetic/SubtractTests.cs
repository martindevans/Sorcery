using Combinators.Machines;
using Combinators.Symbols;
using Combinators.Symbols.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Combinators.Test.Symbols.Arithmetic
{
    [TestClass]
    public class SubtractTests
    {
        readonly IMachine _machine = new StackMachine(ErrorMode.Throw);

        [TestMethod]
        public void Subtract_3_And_2_Returns_1()
        {
            _machine.Push(2);
            _machine.Push(3);
            _machine.Push<Subtract>();

            _machine.Reduce();
            _machine.Reduce();

            Assert.AreEqual(new Number(1), _machine.Symbols.Single());
        }

        [TestMethod]
        public void Subtract_2_And_3_Returns_0()
        {
            //Arithmetic is clamped to zero, so 2 - 3 == 0

            _machine.Push(3);
            _machine.Push(2);
            _machine.Push<Subtract>();

            _machine.Reduce();
            _machine.Reduce();

            Assert.AreEqual(new Number(0), _machine.Symbols.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(PatternMatchException))]
        public void Subtract_Throws_PatternMatchException_When_Not_Given_Numbers()
        {
            _machine.Push<Add>();
            _machine.Push<Add>();
            _machine.Push<Subtract>();

            _machine.Reduce();
            _machine.Reduce();
        }
    }
}

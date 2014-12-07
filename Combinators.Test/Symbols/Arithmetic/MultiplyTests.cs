using Combinators.Machines;
using Combinators.Symbols;
using Combinators.Symbols.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Combinators.Test.Symbols.Arithmetic
{
    [TestClass]
    public class MultiplyTests
    {
        readonly IMachine _machine = new StackMachine(ErrorMode.Throw);

        [TestMethod]
        public void Add_1_And_2_Returns_3()
        {
            _machine.Push(3);
            _machine.Push(2);
            _machine.Push<Multiply>();

            _machine.Reduce();
            _machine.Reduce();

            Assert.AreEqual(new Number(6), _machine.Symbols.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(PatternMatchException))]
        public void Add_Throws_PatternMatchException_When_Not_Given_Numbers()
        {
            _machine.Push<Add>();
            _machine.Push<Add>();
            _machine.Push<Multiply>();

            _machine.Reduce();
            _machine.Reduce();
        }
    }
}

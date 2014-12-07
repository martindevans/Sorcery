using System.Linq;
using Combinators.Machines;
using Combinators.Symbols;
using Combinators.Symbols.Combinators.Arithmetic;
using Combinators.Symbols.Combinators.BCKW;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Combinators.Test.Symbols.Combinators.BCKW
{
    [TestClass]
    public class BCKWTests
    {
        private readonly IMachine _machine = new StackMachine(ErrorMode.Throw); 

        [TestMethod]
        public void B_Applies_X_To_Y_To_Z()
        {
            // B ( ++ ++ 1 ) => 3
            _machine.Push(1);
            _machine.Push(new Increment());
            _machine.Push(new Increment());
            _machine.Push(new B());

            int iterations = 0;
            while (_machine.Reduce())
                iterations++;
            Assert.AreEqual(3, iterations);

            Assert.AreEqual(new Number(3), _machine.Symbols.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(PatternMatchException))]
        public void B_Fails_If_Y_Is_Not_Applicable()
        {
            _machine.Push(1);
            _machine.Push(2);
            _machine.Push(3);
            _machine.Push(new B());

            _machine.Reduce();
            _machine.Reduce();
            _machine.Reduce();
        }

        [TestMethod]
        public void C_Swaps_Y_And_Z()
        {
            _machine.Push(1);
            _machine.Push(2);
            _machine.Push(3);
            _machine.Push(new C());

            int iterations = 0;
            while (_machine.Reduce())
                iterations++;
            Assert.AreEqual(3, iterations);

            var symbols = _machine.Symbols.ToArray();
            Assert.AreEqual(3, symbols.Length);
            Assert.AreEqual(new Number(3), symbols[0]);
            Assert.AreEqual(new Number(1), symbols[1]);
            Assert.AreEqual(new Number(2), symbols[2]);
        }

        [TestMethod]
        public void K_Discards_Y()
        {
            _machine.Push(1);
            _machine.Push(2);
            _machine.Push(new K());

            int iterations = 0;
            while (_machine.Reduce())
                iterations++;
            Assert.AreEqual(2, iterations);

            var symbols = _machine.Symbols.ToArray();
            Assert.AreEqual(1, symbols.Length);
            Assert.AreEqual(new Number(2), symbols[0]);
        }

        [TestMethod]
        public void W_Duplicates_Y()
        {
            _machine.Push(1);
            _machine.Push(2);
            _machine.Push(new W());

            int iterations = 0;
            while (_machine.Reduce())
                iterations++;
            Assert.AreEqual(2, iterations);

            var symbols = _machine.Symbols.ToArray();
            Assert.AreEqual(3, symbols.Length);
            Assert.AreEqual(new Number(2), symbols[0]);
            Assert.AreEqual(new Number(1), symbols[1]);
            Assert.AreEqual(new Number(1), symbols[2]);
        }
    }
}

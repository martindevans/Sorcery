﻿using System.Linq;
using Combinators.Machines;
using Combinators.Symbols;
using Combinators.Symbols.Combinators.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Combinators.Test.Symbols.Combinators.Arithmetic
{
    [TestClass]
    public class IncrementTests
    {
        readonly IMachine _machine = new StackMachine();

        [TestMethod]
        public void Increment_1_Produces_2()
        {
            _machine.Push(1);
            _machine.Push<Increment>();

            Assert.IsTrue(_machine.Reduce());
            Assert.IsFalse(_machine.Reduce());

            Assert.AreEqual(new Number(2), _machine.Symbols.Single());
        }
    }
}

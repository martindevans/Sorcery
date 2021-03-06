﻿using Combinators.Machines;
using Combinators.Symbols.Combinators.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Combinators.Test.Symbols.Combinators.SKI
{
    [TestClass]
    public class Playground
    {
        readonly IMachine _machine = new StackMachine();

        [TestMethod]
        public void Partial_Application_Madness()
        {
            _machine.Push(2);
            _machine.Push<Multiply>();
            _machine.Push<Add>();

            _machine.Reduce();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinators.Machines;
using Combinators.Symbols;
using Combinators.Symbols.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Combinators.Test.Symbols.Arithmetic
{
    [TestClass]
    public class AddTests
    {
        readonly IMachine _machine = new StackMachine();

        [TestMethod]
        public void Add_1_And_2_Returns_3()
        {
            _machine.Push(1);
            _machine.Push(2);
            _machine.Push<Add>();

            _machine.Reduce();
            _machine.Reduce();

            Assert.AreEqual(new Number(3), _machine.Symbols.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(PatternMatchException))]
        public void Add_Throws_PatternMatchException_When_Not_Given_Numbers()
        {
            _machine.Push<Add>();
            _machine.Push<Add>();
            _machine.Push<Add>();

            _machine.Reduce();
            _machine.Reduce();
        }
    }
}

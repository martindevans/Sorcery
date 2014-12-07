using Combinators.Machines;
using Combinators.Symbols.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Combinators.Test.Machines
{
    [TestClass]
    public class StackMachineTest
    {
        readonly IMachine _machine = new StackMachine();

        [TestMethod]
        public void Push_Symbol_Onto_StackMachine_Puts_Symbol_Onto_Stack()
        {
            var sym = new Add();

            _machine.Push(sym);
            Assert.AreEqual(sym, _machine.Symbols.Single());
        }

        [TestMethod]
        public void Pop_Symbol_From_StackMachine_Removes_Symbol_From_Stack()
        {
            var sym = new Add();

            _machine.Push(sym);
            var popped = _machine.Pop();

            Assert.AreEqual(sym, popped);
        }
    }
}

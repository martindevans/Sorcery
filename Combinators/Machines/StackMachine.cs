using System;
using System.Collections.Generic;
using Combinators.Symbols;

namespace Combinators.Machines
{
    public class StackMachine
        : IMachine
    {
        private readonly Stack<ISymbol> _symbols = new Stack<ISymbol>();

        /// <summary>
        /// The symbols on the stack of this machine in top down order
        /// </summary>
        public IEnumerable<ISymbol> Symbols
        {
            get
            {
                return _symbols;
            }
        }

        /// <summary>
        /// Push a new symbol onto the stack
        /// </summary>
        /// <param name="symbol"></param>
        public void Push(ISymbol symbol)
        {
            _symbols.Push(symbol);
        }

        /// <summary>
        /// Remove the top symbol from the stack
        /// </summary>
        /// <returns></returns>
        public ISymbol Pop()
        {
            return _symbols.Pop();
        }

        /// <summary>
        /// Attempt to reduce the stack by performing a substitution
        /// </summary>
        /// <returns>true, if a substitution was performed, otherwise false</returns>
        public bool Reduce()
        {
            return Reduce(_symbols);
        }

        /// <summary>
        /// Reduce a stack of symbols
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns>true, if a substitution was performed, otherwise false</returns>
        public static bool Reduce(Stack<ISymbol> symbols)
        {
            if (symbols == null)
                throw new ArgumentNullException("symbols");
            if (symbols.Count == 0)
                return false;

            //Check if the top of the stack is applicable
            var applicable = symbols.Peek() as IApplicable;
            if (applicable == null)
                return false;

            //Pop off operation
            symbols.Pop();

            //Push result
            foreach (var symbol in applicable.ApplyTo(symbols.Pop()))
                symbols.Push(symbol);

            return true;
        }
    }
}

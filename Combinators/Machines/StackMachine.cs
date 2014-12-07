using System;
using System.Collections.Generic;
using System.Linq;
using Combinators.Symbols;

namespace Combinators.Machines
{
    public class StackMachine
        : IMachine
    {
        private readonly ErrorMode _errorMode;

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

        public StackMachine(ErrorMode errorMode = ErrorMode.Suppress)
        {
            _errorMode = errorMode;
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
            var r = Reduce(_symbols, _errorMode);
            if (!r.HasValue)
                return false;

            for (int i = 0; i < r.Value.Remove; i++)
                _symbols.Pop();

            foreach (var symbol in r.Value.Produced)
                _symbols.Push(symbol);

            return true;
        }

        /// <summary>
        /// Stateless reduction, if reduction causes an exception it will not change the stack
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="errorMode"></param>
        /// <returns></returns>
        private static Reduction? Reduce(IEnumerable<ISymbol> symbols, ErrorMode errorMode)
        {
            //Sanity checks
            if (!symbols.Any())
                return null;

            //Check if the top of the stack is applicable
            var applicable = symbols.First() as IApplicable;
            if (applicable == null)
                return null;

            try
            {
                var result = applicable.ApplyTo(symbols.Skip(1).First()).ToArray();
                return new Reduction(result, 2);
            }
            catch (PatternMatchException)
            {
                switch (errorMode)
                {
                    case ErrorMode.Suppress:
                        return null;
                    case ErrorMode.Throw:
                        throw;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private struct Reduction
        {
            /// <summary>
            /// Number of symbols consumed
            /// </summary>
            public readonly uint Remove;

            /// <summary>
            /// Symbols produced by this reduction
            /// </summary>
            public readonly ISymbol[] Produced;

            public Reduction(ISymbol[] produced, uint remove)
                : this()
            {
                Produced = produced;
                Remove = remove;
            }
        }
    }
}

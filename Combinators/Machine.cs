using System.Collections.Generic;
using System.Numerics;
using Combinators.Symbols;

namespace Combinators
{
    public class Machine
    {
        private readonly Stack<ISymbol> _symbols = new Stack<ISymbol>(); 
        public IEnumerable<ISymbol> Symbols
        {
            get
            {
                return _symbols;
            }
        }

        public void Push(ISymbol symbol)
        {
            _symbols.Push(symbol);
        }

        public void Push(BigInteger number)
        {
            if (number < 0)
                number = 0;

            _symbols.Push(new Number(number));
        }

        public void Push<T>() where T : ISymbol, new()
        {
            Push(new T());
        }

        public bool Reduce()
        {
            //Check if the top of the stack is applicable
            var applicable = _symbols.Peek() as IApplicable;
            if (applicable == null)
                return false;

            //Pop off operation
            _symbols.Pop();

            //Push result
            foreach (var symbol in applicable.ApplyTo(_symbols.Pop()))
                _symbols.Push(symbol);

            return true;
        }
    }
}

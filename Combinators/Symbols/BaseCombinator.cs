using System.Collections.Generic;
using System.Linq;

namespace Combinators.Symbols
{
    internal class PartialApplication
        : IApplicable
    {
        private readonly ISymbol[] _buffer;
        private readonly BaseCombinator _combinator;

        public PartialApplication(IEnumerable<ISymbol> buffer, BaseCombinator combinator)
        {
            _buffer = buffer.ToArray();
            _combinator = combinator;
        }

        public IEnumerable<ISymbol> ApplyTo(ISymbol a)
        {
            if (_buffer.Length + 1 < _combinator.Inputs)
                yield return new PartialApplication(ExtendBuffer(a), _combinator);
            else
                foreach (var symbol in _combinator.Combine(ExtendBuffer(a).ToArray()).Reverse())
                    yield return symbol;   
        }

        private IEnumerable<ISymbol> ExtendBuffer(ISymbol a)
        {
            foreach (var symbol in _buffer)
                yield return symbol;
            yield return a;
        }
    }

    public abstract class BaseCombinator
        : IApplicable
    {
        protected internal abstract uint Inputs { get; }

        protected internal abstract IEnumerable<ISymbol> Combine(params ISymbol[] symbols);

        public IEnumerable<ISymbol> ApplyTo(ISymbol a)
        {
            var p = new PartialApplication(new ISymbol[0], this);
            return p.ApplyTo(a);
        }
    }

    public abstract class BaseCombinator3
        : BaseCombinator
    {
        protected internal override uint Inputs { get { return 3; } }

        protected abstract IEnumerable<ISymbol> Combine(ISymbol a, ISymbol b, ISymbol c);

        protected internal override IEnumerable<ISymbol> Combine(params ISymbol[] symbols)
        {
            return Combine(symbols[0], symbols[1], symbols[2]).ToArray();
        }
    }

    public abstract class BaseCombinator2
        : BaseCombinator
    {
        protected internal override uint Inputs { get { return 2; } }

        protected abstract IEnumerable<ISymbol> Combine(ISymbol a, ISymbol b);

        protected internal override IEnumerable<ISymbol> Combine(params ISymbol[] symbols)
        {
            return Combine(symbols[0], symbols[1]).ToArray();
        }
    }

    public abstract class BaseCombinator1
        : BaseCombinator
    {
        protected internal override uint Inputs { get { return 1; } }

        protected abstract IEnumerable<ISymbol> Combine(ISymbol a);

        protected internal override IEnumerable<ISymbol> Combine(params ISymbol[] symbols)
        {
            return Combine(symbols[0]).ToArray();
        }
    }
}

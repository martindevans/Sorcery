using System.Collections.Generic;

namespace Combinators.Symbols
{
    public interface IApplicable
        : ISymbol
    {
        IEnumerable<ISymbol> ApplyTo(ISymbol a);
    }
}

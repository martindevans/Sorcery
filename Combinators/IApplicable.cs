using System.Collections.Generic;

namespace Combinators
{
    public interface IApplicable
        : ISymbol
    {
        IEnumerable<ISymbol> ApplyTo(ISymbol a);
    }
}

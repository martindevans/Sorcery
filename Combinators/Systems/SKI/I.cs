using System.Collections.Generic;
using Combinators.Symbols;

namespace Combinators.Systems.SKI
{
    /// <summary>
    /// Ix = x
    /// </summary>
    public class I
        : BaseCombinator1
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol a)
        {
            yield return a;
        }
    }
}

using System.Collections.Generic;
using Combinators.Symbols;

namespace Combinators.Systems.SKI
{
    /// <summary>
    /// K x y = x
    /// </summary>
    public class K
        : BaseCombinator2
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y)
        {
            yield return x;
        }
    }
}

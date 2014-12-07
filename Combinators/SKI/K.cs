using System.Collections.Generic;

namespace Combinators.SKI
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

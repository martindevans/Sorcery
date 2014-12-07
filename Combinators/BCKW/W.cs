using System.Collections.Generic;

namespace Combinators.BCKW
{
    /// <summary>
    /// W x y = x y y
    /// </summary>
    public class W
        : BaseCombinator2
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y)
        {
            yield return x;
            yield return y;
            yield return y;
        }
    }
}

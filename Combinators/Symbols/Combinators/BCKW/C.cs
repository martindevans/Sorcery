using System.Collections.Generic;

namespace Combinators.Symbols.Combinators.BCKW
{
    /// <summary>
    /// C x y z = x z y
    /// </summary>
    public class C
        : BaseCombinator3
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y, ISymbol z)
        {
            yield return x;
            yield return z;
            yield return y;
        }
    }
}

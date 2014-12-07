using System.Collections.Generic;

namespace Combinators.SKI
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

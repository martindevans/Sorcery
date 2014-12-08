using System.Collections.Generic;

namespace Combinators.Symbols.Combinators.Arithmetic
{
    /// <summary>
    /// GreaterThan x y = x &gt; y
    /// </summary>
    public class GreaterThan
        : BaseCombinator2
    {
        private const string D = "GreaterThan x y = x > y";

        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y)
        {
            yield return new Boolean(x.Match<Number>(D, "x").Value > y.Match<Number>(D, "y").Value);
        }
    }
}

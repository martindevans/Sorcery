using System.Collections.Generic;

namespace Combinators.Symbols.Combinators.Arithmetic
{
    /// <summary>
    /// LessThan x y = x &lt; y
    /// </summary>
    public class LessThan
        : BaseCombinator2
    {
        private const string D = "LessThan x y = x < y";

        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y)
        {
            yield return new Boolean(x.Match<Number>(D, "x").Value < y.Match<Number>(D, "y").Value);
        }
    }
}

using System.Collections.Generic;

namespace Combinators.Symbols.Combinators.Arithmetic
{
    /// <summary>
    /// EqualTo x y = x == y
    /// </summary>
    public class EqualTo
        : BaseCombinator2
    {
        private const string D = "EqualTo x y = x == y";

        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y)
        {
            yield return new Boolean(x.Match<Number>(D, "x").Value == y.Match<Number>(D, "y").Value);
        }
    }
}

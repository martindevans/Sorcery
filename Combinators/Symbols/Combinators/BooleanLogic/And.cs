using System.Collections.Generic;

namespace Combinators.Symbols.Combinators.BooleanLogic
{
    /// <summary>
    /// And x y = x AND y
    /// </summary>
    public class And
        : BaseCombinator2
    {
        private const string D = "And x y = x AND y";

        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y)
        {
            yield return new Boolean(x.Match<Boolean>(D, "x").Value && y.Match<Boolean>(D, "y").Value);
        }
    }
}

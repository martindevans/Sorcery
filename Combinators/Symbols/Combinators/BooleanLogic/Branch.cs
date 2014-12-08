
using System.Collections.Generic;

namespace Combinators.Symbols.Combinators.BooleanLogic
{
    /// <summary>
    /// Branch x y z = if x then y else z
    /// </summary>
    public class Branch
        : BaseCombinator3
    {
        private const string D = "Branch x y z = if x then y else z";

        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y, ISymbol z)
        {
            if (x.Match<Boolean>(D, "x").Value)
                yield return y;
            else
                yield return z;
        }
    }
}

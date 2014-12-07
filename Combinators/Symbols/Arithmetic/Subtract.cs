using System.Collections.Generic;

namespace Combinators.Symbols.Arithmetic
{
    public class Subtract
        : BaseCombinator2
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol a, ISymbol b)
        {
            var aa = a.Match<Number>("Subtract x y", "x");
            var bb = b.Match<Number>("Subtract x y", "b");

            if (bb.Value >= aa.Value)
                yield return new Number(0);
            else
                yield return new Number(aa.Value - bb.Value);
        }
    }
}

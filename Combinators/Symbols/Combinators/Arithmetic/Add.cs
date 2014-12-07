using System.Collections.Generic;

namespace Combinators.Symbols.Combinators.Arithmetic
{
    public class Add
        : BaseCombinator2
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol a, ISymbol b)
        {
            yield return new Number(
                a.Match<Number>("Add x y", "x").Value +
                b.Match<Number>("Add x y", "y").Value
            );
        }
    }
}

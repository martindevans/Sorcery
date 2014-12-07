using System.Collections.Generic;

namespace Combinators.Symbols.Combinators.Arithmetic
{
    public class Multiply
        : BaseCombinator2
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol a, ISymbol b)
        {
            yield return new Number(
                a.Match<Number>("Multiply x y", "x").Value *
                b.Match<Number>("Multiply x y", "y").Value
            );
        }
    }
}

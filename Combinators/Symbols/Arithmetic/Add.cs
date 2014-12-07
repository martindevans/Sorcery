using System.Collections.Generic;

namespace Combinators.Symbols.Arithmetic
{
    public class Add
        : BaseCombinator2
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol a, ISymbol b)
        {
            var aa = a as Number;
            var bb = b as Number;

            if (aa == null)
                throw new PatternMatchException("Add a is not a Number");
            if (bb == null)
                throw new PatternMatchException("Add b is not a Number");

            yield return new Number(aa.Value + bb.Value);
        }
    }
}

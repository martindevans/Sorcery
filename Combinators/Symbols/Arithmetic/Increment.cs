using System.Collections.Generic;

namespace Combinators.Symbols.Arithmetic
{
    /// <summary>
    /// When applied to a number, make the number one larger
    /// </summary>
    public class Increment
        : IApplicable
    {
        public IEnumerable<ISymbol> ApplyTo(ISymbol a)
        {
            var num = a.Match<Number>("Increment x", "x");

            yield return new Number(num.Value + 1);
        }
    }
}

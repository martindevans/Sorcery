using System.Collections.Generic;
using Combinators.Symbols;

namespace Combinators.Systems.BCKW
{
    /// <summary>
    /// B x y z = x (y z)
    /// </summary>
    public class B
        : BaseCombinator3
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y, ISymbol z)
        {
            //Fail is Y is not applicable
            var app = y as IApplicable;
            if (app == null)
                throw new PatternMatchException("B y is not applicable");

            yield return x;

            foreach (var symbol in app.ApplyTo(z))
                yield return symbol;
        }
    }
}

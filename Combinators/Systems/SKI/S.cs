using System.Collections.Generic;
using System.Linq;
using Combinators.Symbols;

namespace Combinators.Systems.SKI
{
    /// <summary>
    /// Sxyz = xz(yz)
    /// </summary>
    public class S
        : BaseCombinator3
    {
        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y, ISymbol z)
        {
            var xApp = x as IApplicable;
            if (xApp == null)
                throw new PatternMatchException("S x is not applicable");

            var yApp = y as IApplicable;
            if (yApp == null)
                throw new PatternMatchException("S y is not applicable");

            var xz = xApp.ApplyTo(z).Single();
            var xzApp = xz as IApplicable;
            if (xzApp == null)
                throw new PatternMatchException("S xz result is not applicable");

            var yz = yApp.ApplyTo(z).Single();
            return xzApp.ApplyTo(yz);
        }
    }
}

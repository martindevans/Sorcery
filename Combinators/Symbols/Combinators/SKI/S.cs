using System.Collections.Generic;
using System.Linq;

namespace Combinators.Symbols.Combinators.SKI
{
    /// <summary>
    /// Sxyz = xz(yz)
    /// </summary>
    public class S
        : BaseCombinator3
    {
        private const string D = "Sxyz = xz(yz)";

        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y, ISymbol z)
        {
            var yz = y.Match<IApplicable>(D, "y").ApplyTo(z).Single();
            var xz = x.Match<IApplicable>(D, "x").ApplyTo(z).Single().Match<IApplicable>(D, "xz");

            return xz.ApplyTo(yz);
        }
    }
}

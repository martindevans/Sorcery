using System.Collections.Generic;
using System.Linq;

namespace Combinators.Symbols.Combinators.BCKW
{
    /// <summary>
    /// B x y z = x (y z)
    /// </summary>
    public class B
        : BaseCombinator3
    {
        private const string D = "Bxyz = x(yz)";

        protected override IEnumerable<ISymbol> Combine(ISymbol x, ISymbol y, ISymbol z)
        {
            var yz = y.Match<IApplicable>(D, "y").ApplyTo(z).Single();

            return x.Match<IApplicable>(D, "x").ApplyTo(yz);
        }
    }
}

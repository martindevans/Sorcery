using System.Collections.Generic;

namespace Combinators.Symbols
{
    /// <summary>
    /// A symbol which can be applied to other symbols
    /// </summary>
    public interface IApplicable
        : ISymbol
    {
        /// <summary>
        /// Apply this symbol to the other symbol
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        IEnumerable<ISymbol> ApplyTo(ISymbol a);
    }
}

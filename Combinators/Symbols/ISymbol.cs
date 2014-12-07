namespace Combinators.Symbols
{
    public interface ISymbol
    {
    }

    public static class ISymbolExtensions
    {
        public static T Match<T>(this ISymbol symbol, string applicatorName, string argumentName) where T : ISymbol
        {
            if (symbol is T)
                return (T)symbol;

            throw new PatternMatchException(string.Format("Application {0} requires that argument {1} is {2}", applicatorName, argumentName, typeof(T).Name));
        }
    }
}

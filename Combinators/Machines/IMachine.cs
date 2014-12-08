using Combinators.Symbols;
using System.Collections.Generic;
using System.Numerics;

namespace Combinators.Machines
{
    public interface IMachine
    {
        /// <summary>
        /// Get the symbols of this machine
        /// </summary>
        IEnumerable<ISymbol> Symbols { get; }

        /// <summary>
        /// Add a new symbol to this machine
        /// </summary>
        /// <param name="symbol"></param>
        void Push(ISymbol symbol);

        /// <summary>
        /// Remove a symbol from this machine
        /// </summary>
        /// <returns></returns>
        ISymbol Pop();

        /// <summary>
        /// Attempt to reduce the symbols in this machine
        /// </summary>
        /// <returns>true, if a substitution was performed, otherwise false</returns>
        bool Reduce();
    }

    public static class IMachineExtensions
    {
        /// <summary>
        /// Push a new number symbol onto the stack
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="number"></param>
        public static void Push(this IMachine machine, BigInteger number)
        {
            if (number < 0)
                number = 0;

            machine.Push(new Number(number));
        }

        /// <summary>
        /// Push a new generic symbol onto the stack
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Push<T>(this IMachine machine) where T : ISymbol, new()
        {
            machine.Push(new T());
        }
    }
}

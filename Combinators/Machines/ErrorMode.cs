
namespace Combinators.Machines
{
    public enum ErrorMode
    {
        /// <summary>
        /// Reductions suppress errors and make no changes to the machine
        /// </summary>
        Suppress,

        /// <summary>
        /// Throw errors as exceptions
        /// </summary>
        Throw
    }
}

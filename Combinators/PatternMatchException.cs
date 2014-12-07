using System;

namespace Combinators
{
    public class PatternMatchException
        : InvalidOperationException
    {
        public PatternMatchException(string message)
            : base(message)
        {
        }
    }
}

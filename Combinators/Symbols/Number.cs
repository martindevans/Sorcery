using System;
using System.Globalization;
using System.Numerics;

namespace Combinators.Symbols
{
    public class Number
        : ISymbol, IEquatable<Number>
    {
        private readonly BigInteger _value;
        public BigInteger Value
        {
            get
            {
                return _value;
            }
        }

        public Number(BigInteger value)
        {
            _value = value;
        }

        public bool Equals(Number other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            var a = obj as Number;
            if (a != null)
                return Equals(a);

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}

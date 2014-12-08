using System;
using System.Globalization;

namespace Combinators.Symbols
{
    public class Boolean
        : ISymbol, IEquatable<Boolean>
    {
        private readonly bool _value;
        public bool Value
        {
            get
            {
                return _value;
            }
        }

        public Boolean(bool value)
        {
            _value = value;
        }

        public bool Equals(Boolean other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            var a = obj as Boolean;
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

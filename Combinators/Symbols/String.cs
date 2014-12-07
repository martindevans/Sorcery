using System;

namespace Combinators.Symbols
{
    public class String
        : ISymbol, IEquatable<string>, IEquatable<String>
    {
        private readonly string _value;
        public string Value
        {
            get
            {
                return _value;
            }
        }

        public String(string value)
        {
            _value = value;
        }

        public bool Equals(string other)
        {
            return other == _value;
        }

        public bool Equals(String other)
        {
            return Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            var a = obj as String;
            if (a != null)
                return Equals(a);

            var s = obj as string;
            if (s != null)
                return Equals(s);

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}

﻿using System.Collections.Generic;

namespace Combinators.Symbols.Arithmetic
{
    /// <summary>
    /// When applied to a number, make the number one smaller (clamp at zero)
    /// </summary>
    public class Decrement
       : IApplicable
    {
        public IEnumerable<ISymbol> ApplyTo(ISymbol a)
        {
            var num = a as Number;
            if (num == null)
                throw new PatternMatchException("Increment not applied to a Number");

            if (num.Value == 0)
                yield return a;
            else
                yield return new Number(num.Value - 1);
            
        }
    }
}
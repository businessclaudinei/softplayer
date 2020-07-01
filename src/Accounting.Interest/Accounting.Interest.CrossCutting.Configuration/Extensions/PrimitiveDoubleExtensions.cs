using System;

namespace Accounting.Interest.CrossCutting.Configuration.Extensions
{
    public static class PrimitiveDoubleExtensions
    {
        public static double Truncate(this double value, uint places)
        {
            if (places == 0) return Math.Truncate(value);

            var decimalPlaces = Math.Pow(10, places);

            return Math.Truncate(decimalPlaces * value) / decimalPlaces;
        }
    }
}

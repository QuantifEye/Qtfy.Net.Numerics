// <copyright file="SpecialFunctions.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    /// <summary>
    /// A collection of special mathematical functions.
    /// </summary>
    public static class SpecialFunctions
    {
        /// <summary>
        /// Calculates the error function (also called the Gauss error function).
        /// <see href="https://en.wikipedia.org/wiki/Error_function"/>.
        /// </summary>
        /// <param name="x">
        /// The point at which to evaluate the error function.
        /// </param>
        /// <returns>
        /// A double in the range [-1, 1].
        /// </returns>
        public static double Erf(double x)
        {
            return MathNet.Numerics.SpecialFunctions.Erf(x);
        }

        /// <summary>
        /// Calculates the inverse error of the error function.
        /// <see href="https://en.wikipedia.org/wiki/Error_function#Inverse_functions"/>.
        /// </summary>
        /// <param name="y">
        /// The value at which to evaluate the function.
        /// </param>
        /// <returns>
        /// The value of the inverse error function evaluated at <paramref name="y"/>.
        /// </returns>
        public static double ErfInv(double y)
        {
            if (y < -1d || y > 1d)
            {
                return double.NaN;
            }

            return MathNet.Numerics.SpecialFunctions.ErfInv(y);
        }
    }
}

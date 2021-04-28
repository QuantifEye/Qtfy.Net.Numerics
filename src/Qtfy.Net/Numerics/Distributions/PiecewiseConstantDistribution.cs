// <copyright file="PiecewiseConstantDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A piecewise constant distribution is described distribution which is uniformly distributed within sub intervals.
    /// This can be thought of as being analogous to the distribution implied by a histogram.
    /// </summary>
    /// <para>
    /// A piecewise constant distribution is described by n distinct domain points,
    /// where n is greater than 1, and n - 1 non-negative weight.
    /// let S be the sum of all weights.
    /// let w_i be the weight assigned to interval i.
    /// let i_lower be the lower bound of interval i.
    /// let i_upper be the upper bound of an interval i.
    /// Then the probability that a random variable will fall in interval i is equal to
    /// w_i / (S * (i_upper - i_lower)).
    /// </para>
    public class PiecewiseConstantDistribution : IDistribution<double>
    {
        private readonly double[] boundaries;

        private readonly double[] cumulativeProbabilities;

        private PiecewiseConstantDistribution(double[] boundaries, double[] cumulativeProbabilities)
        {
            this.boundaries = boundaries;
            this.cumulativeProbabilities = cumulativeProbabilities;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PiecewiseConstantDistribution"/> class.
        /// </summary>
        /// <param name="domain">
        /// A sequence of strictly monotonically increasing values.
        /// </param>
        /// <param name="weights">
        /// A sequence of non negative weights.
        /// </param>
        /// <returns>
        /// Returns a new <see cref="PiecewiseConstantDistribution"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// if the number of elements in <paramref name="domain"/> is less than 2.
        /// if the number of element in <paramref name="weights"/> is not one less than the number of elements in <paramref name="domain"/>.
        /// if <paramref name="domain"/> is not sorted and unique.
        /// if any of the values in <paramref name="weights"/> is less than zero.
        /// </exception>
        public static PiecewiseConstantDistribution Create(IEnumerable<double> domain, IEnumerable<double> weights)
        {
            var b = domain.ToArray();
            var cp = new[] { 0d }.Concat(weights).ToArray();

            if (b.Length < 2 || b.Length != cp.Length)
            {
                throw new ArgumentException("Require at least two boundaries");
            }

            if (!IsStrictlyMonotonic(b))
            {
                throw new ArgumentException("values must be strictly monotonic.");
            }

            if (!AllNonNegative(cp))
            {
                throw new ArgumentException("Weights must be non negative");
            }

            for (int i = 1; i < cp.Length; ++i)
            {
                cp[i] = cp[i - 1] + cp[i];
            }

            var total = cp[^1];
            for (int i = 0; i < cp.Length; ++i)
            {
                cp[i] /= total;
            }

            return new PiecewiseConstantDistribution(b, cp);
        }

        /// <inheritdoc/>
        public double Quantile(double probability)
        {
            if (probability >= 0d && probability <= 1d)
            {
                var domain = this.cumulativeProbabilities;
                var range = this.boundaries;
                int i = 0;
                for (; i < domain.Length; ++i)
                {
                    if (domain[i] >= probability)
                    {
                        break;
                    }
                }

                return domain[i] == probability
                    ? this.boundaries[i]
                    : LinearInterpolate(domain[i - 1], domain[i], range[i - 1], range[i], probability);
            }

            throw new ArgumentException("invalid probability");
        }

        /// <inheritdoc/>
        public double CumulativeDistribution(double x)
        {
            var domain = this.boundaries;
            var range = this.cumulativeProbabilities;
            if (x <= domain[0])
            {
                return 0d;
            }

            if (x >= domain[^1])
            {
                return 1d;
            }

            var i = Array.BinarySearch(domain, 0, domain.Length, x);
            if (i < 0)
            {
                i = ~i;
                return LinearInterpolate(domain[i - 1], domain[i], range[i - 1], range[i], x);
            }
            else
            {
                return range[i];
            }
        }

        private static double LinearInterpolate(double x0, double x1, double y0, double y1, double x)
        {
            var m = (y1 - y0) / (x1 - x0);
            return y0 + m * (x - x0);
        }

        private static bool IsStrictlyMonotonic(double[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i - 1] >= array[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AllNonNegative(double[] array)
        {
            for (var i = 0; i < array.Length; ++i)
            {
                if (array[i] < 0d)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

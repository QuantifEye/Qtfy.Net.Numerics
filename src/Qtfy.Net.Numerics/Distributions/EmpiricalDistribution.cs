// <copyright file="EmpiricalDistribution.cs" company="QuantifEye">
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
    /// An empirical distribution object.
    /// </summary>
    public class EmpiricalDistribution
    {
        private readonly double[] uniqueValues;

        private readonly int[] counts;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmpiricalDistribution"/> class.
        /// </summary>
        /// <param name="observations">
        /// The observations that make up the empirical distribution.
        /// The observations are assumed to be statistically independent.
        /// </param>
        public EmpiricalDistribution(IEnumerable<double> observations)
        {
            if (observations is null)
            {
                throw new ArgumentNullException(nameof(observations));
            }

            var temp = observations.ToArray();
            if (temp.Length == 0)
            {
                throw new ArgumentException("Cannot construct empty empirical distribution.");
            }

            Array.Sort(temp);
            if (double.IsNaN(temp[0]))
            {
                throw new ArgumentException("Empirical distribution cannot contain NaN values.");
            }

            this.Mean = temp.Average();
            this.uniqueValues = GetUniqueValues(temp, out this.counts);
        }

        /// <inheritdoc />
        public double Mean { get; }

        /// <inheritdoc />
        public double CDF(double x)
        {
            var i = Array.BinarySearch(this.uniqueValues, x);
            if (i < 0)
            {
                i = ~i - 1;
            }

            return this.counts[i];
        }

        private static double[] GetUniqueValues(double[] values, out int[] uniqueCounts)
        {
            var counts = new int[values.Length];
            var vIndex = 0;
            var cIndex = 0;
            var previous = values[0];
            while (++vIndex < values.Length)
            {
                var current = values[vIndex];
                if (current != previous)
                {
                    counts[cIndex] = vIndex;
                    values[cIndex] = previous;
                    ++cIndex;
                    previous = current;
                }
            }

            counts[cIndex] = vIndex;
            values[cIndex] = previous;
            ++cIndex;

            uniqueCounts = counts.Copy(cIndex);
            return values.Copy(cIndex);
        }
    }
}

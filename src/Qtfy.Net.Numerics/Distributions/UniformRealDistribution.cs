// <copyright file="UniformRealDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    using System;

    /// <summary>
    /// A uniform real (continuous) distribution object.
    /// </summary>
    public class UniformRealDistribution : IContiniousDistribution
    {
        private readonly double density;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniformRealDistribution"/> class.
        /// </summary>
        /// <param name="min">
        /// The minimum parameter.
        /// </param>
        /// <param name="max">
        /// The maximum parameter.
        /// </param>
        public UniformRealDistribution(double min, double max)
        {
            var range = max - min;
            if (max <= min)
            {
                throw new ArgumentException("min must be less than max");
            }

            if (range == 0d)
            {
                throw new ArgumentException("underflow error");
            }

            var variance = range * range / 12d;
            this.Mean = (max + min) / 2d;
            this.Variance = variance;
            this.StandardDeviation = Math.Sqrt(variance);
            this.Min = min;
            this.Max = max;
            this.density = 1d / range;
        }

        /// <summary>
        /// Gets the minimum parameter.
        /// </summary>
        public double Min { get; }

        /// <summary>
        /// Gets the maximum parameter.
        /// </summary>
        public double Max { get; }

        /// <inheritdoc />
        public double Mean { get; }


        /// <inheritdoc />
        public double Variance { get; }

        /// <inheritdoc />
        public double StandardDeviation { get; }

        /// <inheritdoc />
        public double CumulativeDistribution(double x)
        {
            if (x <= this.Min)
            {
                return 0d;
            }

            if (x >= this.Max)
            {
                return 1d;
            }

            return (x - this.Min) / (this.Max - this.Min);
        }

        /// <inheritdoc/>
        public double Density(double x)
        {
            return x < this.Min || x > this.Max ? 0d : this.density;
        }

        /// <inheritdoc/>
        public double DensityLn(double x)
        {
            return x < this.Min || x > this.Max
                ? double.NegativeInfinity
                : -Math.Log(this.Max - this.Min);
        }

        /// <inheritdoc />
        public double Quantile(double probability)
        {
            if (probability < 0d || probability > 1d)
            {
                throw new ArgumentException();
            }

            return Math.FusedMultiplyAdd(this.Max - this.Min, probability, this.Min);
        }
    }
}

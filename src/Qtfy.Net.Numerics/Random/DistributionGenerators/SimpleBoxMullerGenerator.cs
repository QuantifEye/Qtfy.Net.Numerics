// <copyright file="SimpleBoxMullerGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.DistributionGenerators
{
    using System;
    using Qtfy.Net.Numerics.Distributions;

    /// <summary>
    /// The simple form box muller transform.
    /// </summary>
    public class SimpleBoxMullerGenerator : IDistributionGenerator<double>
    {
        /// <summary>
        /// Get algorithm generates two values at a time. One is cached in this variable.
        /// </summary>
        private double z1;

        /// <summary>
        /// An indication if <see cref="z1"/> should be returned by the algorithm, or if
        /// more values should be generated.
        /// </summary>
        private bool takeZ1;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBoxMullerGenerator"/> class.
        /// </summary>
        /// <param name="generator">
        /// The source generator used to generate uniformly distributed random numbers.
        /// </param>
        /// <param name="mean">
        /// The mean of the generated values.
        /// </param>
        /// <param name="sigma">
        /// The standard deviation of the generated values.
        /// </param>
        public SimpleBoxMullerGenerator(IUniformBitGenerator generator, double mean, double sigma)
        {
            this.Generator = generator;
            this.Distribution = new NormalDistribution(mean, sigma);
        }

        /// <summary>
        /// Gets the underlying random number generator.
        /// </summary>
        public IUniformBitGenerator Generator { get; }

        /// <inheritdoc />
        public IDistribution<double> Distribution { get; }

        /// <inheritdoc />
        public double GetNext()
        {
            if (this.takeZ1)
            {
                this.takeZ1 = false;
                return this.z1;
            }
            else
            {
                this.takeZ1 = true;
                var u1 = this.Generator.NextStandardUniform();
                var u2 = this.Generator.NextStandardUniform();
                var x0 = Constants.TwoPi * u2;
                var x1 = Math.Sqrt(-2d * Math.Log(u1));
                this.z1 = x0 * Math.Sin(x1);
                return x0 * Math.Cos(x1);
            }
        }
    }
}

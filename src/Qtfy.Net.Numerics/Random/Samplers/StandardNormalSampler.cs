// <copyright file="StandardNormalSampler.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    using System;
    using static System.Math;

    /// <summary>
    /// The simple form box muller transform.
    /// </summary>
    public class StandardNormalSampler : ISampler<double>
    {
        /// <summary>
        /// The underlying random number generator.
        /// </summary>
        private IRandomNumberEngine engine;

        /// <summary>
        /// Get algorithm generates two values at a time. One is cached in this variable.
        /// </summary>
        private double spare;

        /// <summary>
        /// An indication if <see cref="spare"/> should be returned by the algorithm, or if
        /// more values should be generated.
        /// </summary>
        private bool hasSpare;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardNormalSampler"/> class.
        /// </summary>
        /// <param name="engine">
        /// The pseudo random engine used to generate random numbers.
        /// </param>
        public StandardNormalSampler(IRandomNumberEngine engine)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        /// <inheritdoc />
        public double GetNext()
        {
            if (this.hasSpare)
            {
                this.hasSpare = false;
                return this.spare;
            }
            else
            {
                var engine = this.engine;
                double s, u, v, logS;
                do
                {
                    u = FusedMultiplyAdd(engine.NextCanonical(), 2d, -1d);
                    v = FusedMultiplyAdd(engine.NextCanonical(), 2d, -1d);
                    s = u * u + v * v;
                }
                while (s >= 1d || u == 0d || v == 0d);

                if (s > 1e-4)
                {
                    logS = Log(s);
                }
                else
                {
                    var exp = -ILogB(Max(Abs(u), Abs(v)));
                    u = ScaleB(u, exp);
                    v = ScaleB(v, exp);
                    s = u * u + v * v;
                    logS = FusedMultiplyAdd(exp, -Constants.TwoLnTwo, Log(s));
                }

                var f = Sqrt(-2d * logS / s);
                this.spare = f * v;
                this.hasSpare = true;
                return f * u;
            }
        }
    }
}

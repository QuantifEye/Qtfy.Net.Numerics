// <copyright file="GaussianCopula.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.CopulaGenerators
{
    /// <summary>
    /// The gaussian copula.
    /// </summary>
    public class GaussianCopula : ICopulaGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GaussianCopula"/> class.
        /// </summary>
        /// <param name="marginals">
        /// The marginal distributions.
        /// </param>
        /// <param name="mean">
        /// The copula mean.
        /// </param>
        /// <param name="sigma">
        /// The copula covariance matrix.
        /// </param>
        public GaussianCopula(IDistribution<double>[] marginals, double[] mean, double[,] sigma)
        {
            this.Marginals = marginals;
            this.Mean = mean;
            this.Sigma = sigma;
        }

        /// <summary>
        /// Gets the marginals of the generated variables.
        /// </summary>
        public IDistribution<double>[] Marginals { get; }

        /// <summary>
        /// Gets the mean of the normal distribution.
        /// </summary>
        public double[] Mean { get; }

        /// <summary>
        /// Gets the covariance matrix of the distribution.
        /// </summary>
        public double[,] Sigma { get; }

        // TODO: naming?
        public double[] NextVector()
        {
            throw new System.NotImplementedException();
        }
    }
}

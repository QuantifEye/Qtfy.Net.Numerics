// <copyright file="BigRationalTests.ArithmeticOperators.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Tests
{
    using MathNet.Numerics.LinearAlgebra.Double;
    using NUnit.Framework;

    public class MatrixMathTests
    {
        [Test]
        public void TestCheleskyDecomposition()
        {
            var input = new double[,]
            {
                { 1.00, 0.50, 0.75 },
                { 0.50, 1.00, 0.25 },
                { 0.75, 0.25, 1.00 },
            };

            var expected = DenseMatrix.OfArray(input).Cholesky().Factor.ToArray();

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                }
            }
        }
    }
}

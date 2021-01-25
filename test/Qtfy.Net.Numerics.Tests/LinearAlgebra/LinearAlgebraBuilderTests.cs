// <copyright file="LinearAlgebraBuilderTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Tests
{
    using NUnit.Framework;

    public class LinearAlgebraBuilderTests
    {
        public class MockMatrix
        {
            public double[] Data { get; set; }
        }

        public class MockLinearAlgebraBuilder : LinearAlgebra.LinearAlgebraBuilder<MockMatrix>
        {
            public MockLinearAlgebraBuilder(double[] data)
                : base(data)
            {
            }

            private protected override MockMatrix Factory(double[] data)
                => new () { Data = data };

            public double[] Data => this.data;
        }

        [Test]
        public void TestMove()
        {
            var builder = new MockLinearAlgebraBuilder(new[] {1d, 2d});
            var data = builder.Data;
            var matrix = builder.BuildMove();
            Assert.IsNull(builder.Data);
            Assert.AreSame(matrix.Data, data);
        }


        [Test]
        public void TestCopy()
        {
            var builder = new MockLinearAlgebraBuilder(new[] {1d, 2d});
            var matrix = builder.BuildCopy();
            Assert.AreNotSame(builder.Data, matrix.Data);
            Assert.AreEqual(builder.Data, matrix.Data);
        }
    }
}

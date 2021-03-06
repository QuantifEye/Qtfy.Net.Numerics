// <copyright file="DoubleSamplerTester.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.Samplers
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class DoubleSamplerTester : SamplerTester<double>
    {
        public override double Mean(IEnumerable<double> sample)
        {
            return sample.Average();
        }
    }
}

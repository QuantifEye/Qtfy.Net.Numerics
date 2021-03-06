// <copyright file="NonFiniteDoubles.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.TestUtilities.TestCases
{
    using System.Collections;

    public class NonFiniteDoubles : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return double.NegativeInfinity;
            yield return double.PositiveInfinity;
            yield return double.NaN;
        }
    }
}


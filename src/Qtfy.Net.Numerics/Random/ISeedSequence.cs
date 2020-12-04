// <copyright file="RationalRounding.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    public interface ISeedSequence<T>
    {
        T[] SeedArray(uint arraySize);
    }
}
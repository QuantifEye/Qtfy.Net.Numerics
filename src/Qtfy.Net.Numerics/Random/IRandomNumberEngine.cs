// <copyright file="IRandomNumberEngine.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    /// <summary>
    /// The common interface that all bit generators that produce uniform values share.
    /// </summary>
    public interface IRandomNumberEngine
    {
        /// <summary>
        /// Generates an <see cref="uint"/> that is uniformly distributed across all possible <see cref="uint"/> values,
        /// this is [0, 2^32).
        /// </summary>
        /// <returns>
        /// An <see cref="uint"/> that is uniformly distributed across all possible <see cref="uint"/> values.
        /// </returns>
        uint NextUInt();

        /// <summary>
        /// Generates a <see cref="uint"/> that is uniformly distributed across all possible <see cref="uint"/> values,
        /// this is [0, max].
        /// </summary>
        /// <param name="max">
        /// The largest possible number that will be returned.
        /// </param>
        /// <returns>
        /// A <see cref="uint"/> that is uniformly distributed across all possible <see cref="uint"/> values,
        /// this is [0, max].
        /// </returns>
        uint NextUInt(uint max);

        /// <summary>
        /// Generates a <see cref="uint"/> that is uniformly distributed in the interval
        /// [<paramref name="min"/>, <paramref name="max"/>].
        /// </summary>
        /// <param name="min">
        /// The smallest number that will be generated.
        /// </param>
        /// <param name="max">
        /// The greatest number that will be generated.
        /// </param>
        /// <returns>
        /// A <see cref="ulong"/> that is uniformly distributed in the interval [0, <paramref name="max"/>].
        /// </returns>
        uint NextUInt(uint min, uint max);

        /// <summary>
        /// Generates an <see cref="int"/> that is uniformly distributed across all possible <see cref="int"/> values,
        /// this is [-2^31, 2^31).
        /// </summary>
        /// <returns>
        /// An <see cref="int"/> that is uniformly distributed across all possible <see cref="int"/> values.
        /// </returns>
        int NextInt();

        /// <summary>
        /// Generates a <see cref="int"/> that is uniformly distributed across all possible <see cref="int"/> values,
        /// this is [0, max].
        /// </summary>
        /// <param name="max">
        /// The largest possible number that will be returned.
        /// </param>
        /// <returns>
        /// A <see cref="int"/> that is uniformly distributed across all possible <see cref="int"/> values,
        /// this is [0, max].
        /// </returns>
        int NextInt(int max);

        /// <summary>
        /// Generates a <see cref="int"/> that is uniformly distributed in the interval
        /// [<paramref name="min"/>, <paramref name="max"/>].
        /// </summary>
        /// <param name="min">
        /// The smallest number that will be generated.
        /// </param>
        /// <param name="max">
        /// The greatest number that will be generated.
        /// </param>
        /// <returns>
        /// A <see cref="int"/> that is uniformly distributed in the interval
        /// [<paramref name="min"/>, <paramref name="max"/>].
        /// </returns>
        int NextInt(int min, int max);

        /// <summary>
        /// Generates an <see cref="ulong"/> that is uniformly distributed across all possible <see cref="ulong"/> values,
        /// this is [0, 2^64).
        /// </summary>
        /// <returns>
        /// An <see cref="ulong"/> that is uniformly distributed across all possible <see cref="ulong"/> values.
        /// </returns>
        ulong NextULong();

        /// <summary>
        /// Generates a <see cref="ulong"/> that is uniformly distributed across all possible <see cref="ulong"/> values,
        /// this is [0, max].
        /// </summary>
        /// <param name="max">
        /// The largest possible number that will be returned.
        /// </param>
        /// <returns>
        /// A <see cref="ulong"/> that is uniformly distributed across all possible <see cref="ulong"/> values,
        /// this is [0, max].
        /// </returns>
        ulong NextULong(ulong max);

        /// <summary>
        /// Generates a <see cref="ulong"/> that is uniformly distributed in the interval
        /// [<paramref name="min"/>, <paramref name="max"/>].
        /// </summary>
        /// <param name="min">
        /// The smallest number that will be generated.
        /// </param>
        /// <param name="max">
        /// The greatest number that will be generated.
        /// </param>
        /// <returns>
        /// A <see cref="ulong"/> that is uniformly distributed in the interval
        /// [<paramref name="min"/>, <paramref name="max"/>].
        /// </returns>
        ulong NextULong(ulong min, ulong max);

        /// <summary>
        /// Generates a <see cref="long"/> that is uniformly distributed across all possible <see cref="long"/> values,
        /// this is [-(2^63), 2^63).
        /// </summary>
        /// <returns>
        /// An <see cref="long"/> that is uniformly distributed across all possible <see cref="long"/> values.
        /// </returns>
        long NextLong();

        /// <summary>
        /// Generates a <see cref="long"/> that is uniformly distributed across all possible <see cref="long"/> values,
        /// this is [0, max].
        /// </summary>
        /// <param name="max">
        /// The largest possible number that will be returned.
        /// </param>
        /// <returns>
        /// A <see cref="long"/> that is uniformly distributed across all possible <see cref="long"/> values,
        /// this is [0, max].
        /// </returns>
        long NextLong(long max);

        /// <summary>
        /// Generates a <see cref="long"/> that is uniformly distributed in the interval
        /// [<paramref name="min"/>, <paramref name="max"/>].
        /// </summary>
        /// <param name="min">
        /// The smallest number that will be generated.
        /// </param>
        /// <param name="max">
        /// The greatest number that will be generated.
        /// </param>
        /// <returns>
        /// A <see cref="long"/> that is uniformly distributed in the interval
        /// [<paramref name="min"/>, <paramref name="max"/>].
        /// </returns>
        long NextLong(long min, long max);

        /// <summary>
        /// Generates a standard real uniform random variable distributed on the interval [0, 1).
        /// </summary>
        /// <returns>
        /// A standard real uniform random variable distributed on the interval [0, 1).
        /// </returns>
        double NextCanonical();

        /// <summary>
        /// Generates a standard real uniform random variable distributed on the interval (0, 1].
        /// </summary>
        /// <returns>
        /// A standard uniform random variable distributed on the interval [0, 1).
        /// </returns>
        public double NextIncrementedCanonical();

        /// <summary>
        /// Generates a standard real uniform random variable distributed on the interval (-1, 1).
        /// </summary>
        /// <returns>
        /// A standard uniform random variable distributed on the interval (-1, 1).
        /// </returns>
        public double NextSymmetricCanonical();
    }
}

// <copyright file="Vector.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System;

    /// <summary>
    /// A linear algebra vector that is stored contiguously.
    /// </summary>
    public sealed partial class Vector : IVector
    {
        /// <summary>
        /// The data of the vector.
        /// </summary>
        private readonly double[] data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="data">
        /// The data of the vector.
        /// </param>
        internal Vector(double[] data)
        {
            if (data.Length == 0)
            {
                throw new LinearAlgebraException();
            }

            this.data = data;
        }

        /// <summary>
        /// Gets the data of the vector.
        /// </summary>
        internal double[] Data
        {
            get => this.data;
        }

        /// <inheritdoc />
        public int Length
        {
            get => this.data.Length;
        }

        /// <inheritdoc />
        public double this[int i]
        {
            get => this.data[i];
        }

        /// <summary>
        /// Multiplies a vector with a vector. Producing the euclidean dot product.
        /// </summary>
        /// <param name="left">
        /// The left vector to multiply.
        /// </param>
        /// <param name="right">
        /// The right vector to multiply.
        /// </param>
        /// <returns>
        /// The euclidean inner product.
        /// </returns>
        public static double operator *(Vector left, Vector right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Scales a vector by a constant.
        /// </summary>
        /// <param name="left">
        /// The vector to scale.
        /// </param>
        /// <param name="right">
        /// The scaling factor.
        /// </param>
        /// <returns>
        /// A new scaled vector.
        /// </returns>
        public static Vector operator *(Vector left, double right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs vector addition of <paramref name="left"/> and <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The left vector to add.
        /// </param>
        /// <param name="right">
        /// The right vector to add.
        /// </param>
        /// <returns>
        /// The sum of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static Vector operator +(Vector left, Vector right)
        {
            return new (ArrayMath.Add(left.data, right.data));
        }

        /// <summary>
        /// Adds the scalar <paramref name="right"/> to each element in <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The left vector to add.
        /// </param>
        /// <param name="right">
        /// The right vector to add.
        /// </param>
        /// <returns>
        /// A new vector that is the result of adding
        /// <paramref name="right"/> to each element in <paramref name="left"/>.
        /// </returns>
        public static Vector operator +(Vector left, double right)
        {
            return new (ArrayMath.Add(left.data, right));
        }

        /// <summary>
        /// Subtracts each element in <paramref name="right"/> from each element in <paramref name="left"/>.
        /// </summary>
        /// <param name="left">
        /// The vector to subtract from.
        /// </param>
        /// <param name="right">
        /// The vector to subtract.
        /// </param>
        /// <returns>
        /// A new vector where each element in <paramref name="right"/> has been subtracted from each element in
        /// <paramref name="left."/>.
        /// </returns>
        public static Vector operator -(Vector left, Vector right)
        {
            return new (ArrayMath.Subtract(left.data, right.data));
        }

        /// <summary>
        /// Subtracts  <paramref name="right"/> from each element in <paramref name="left"/>.
        /// </summary>
        /// <param name="left">
        /// The vector to subtract from.
        /// </param>
        /// <param name="right">
        /// The value to subtract from each element in <paramref name="left"/>.
        /// </param>
        /// <returns>
        /// A new vector where <paramref name="right"/> has been subtracted from each element in
        /// <paramref name="left"/>.
        /// </returns>
        public static Vector operator -(Vector left, double right)
        {
            return left + -right;
        }
    }
}

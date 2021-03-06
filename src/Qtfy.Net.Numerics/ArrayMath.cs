// <copyright file="ArrayMath.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    using System;

    /// <summary>
    /// A collection of methods that facilitate arithmetic using arrays.
    /// </summary>
    public static class ArrayMath
    {
        /// <summary>
        /// Copies an array.
        /// </summary>
        /// <param name="self">
        /// The array to copy.
        /// </param>
        /// <typeparam name="T">
        /// The type of the elements in the array.
        /// </typeparam>
        /// <returns>
        /// A copy of the array.
        /// </returns>
        public static T[] Copy<T>(this T[] self)
        {
            return (T[])self.Clone();
        }

        /// <summary>
        /// Copies the first <paramref name="count"/> elements from <paramref name="self"/> to
        /// a new array.
        /// </summary>
        /// <param name="self">
        /// The array to copy from.
        /// </param>
        /// <param name="count">
        /// The number of elements to copy.
        /// </param>
        /// <typeparam name="T">
        /// The type of the elements to copy.
        /// </typeparam>
        /// <returns>
        /// A new array that contains the first <paramref name="count"/> elements in <paramref name="self"/>.
        /// </returns>
        public static T[] Copy<T>(this T[] self, int count)
        {
            var result = new T[count];
            Array.Copy(self, result, count);
            return result;
        }

        /// <summary>
        /// Adds <paramref name="right"/> to each element in <paramref name="left"/>.
        /// </summary>
        /// <param name="left">
        /// The array to add to.
        /// </param>
        /// <param name="right">
        /// The value to add.
        /// </param>
        /// <returns>
        /// A new array that is teh result of adding <paramref name="right"/> to each element in
        /// <paramref name="left"/>.
        /// </returns>
        public static double[] Add(double[] left, double right)
        {
            var result = left.Copy();
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] += right;
            }

            return result;
        }

        /// <summary>
        /// Adds each element in <paramref name="left"/> to each element in <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The left array to add.
        /// </param>
        /// <param name="right">
        /// The right array to add.
        /// </param>
        /// <returns>
        /// A new array that os the result of adding each element in <paramref name="left"/> to each element in
        /// <paramref name="right"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If <paramref name="left"/> is not the same length as <paramref name="right"/>.
        /// </exception>
        public static double[] Add(double[] left, double[] right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Arrays must have same length");
            }

            var result = left.Copy();
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] += right[i];
            }

            return result;
        }

        /// <summary>
        /// Subtracts <paramref name="right"/> from each element in left.
        /// </summary>
        /// <param name="left">
        /// The array to subtract from.
        /// </param>
        /// <param name="right">
        /// The value to subtract.
        /// </param>
        /// <returns>
        /// A new array that is the result of subtracting <paramref name="right"/> from each element in
        /// <paramref name="left"/>.
        /// </returns>
        public static double[] Subtract(double[] left, double right)
        {
            var result = left.Copy();
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] -= right;
            }

            return result;
        }

        /// <summary>
        /// Subtracts each element in <paramref name="right"/> from each element in <paramref name="left"/>.
        /// </summary>
        /// <param name="left">
        /// The array to subtract from.
        /// </param>
        /// <param name="right">
        /// The array to subtract.
        /// </param>
        /// <returns>
        /// A new array that is the result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If <paramref name="left"/> is not the same length as <paramref name="right"/>.
        /// </exception>
        public static double[] Subtract(double[] left, double[] right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Arrays must have same length");
            }

            var result = left.Copy();
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] -= right[i];
            }

            return result;
        }

        /// <summary>
        /// Multiplies each element in <paramref name="left"/> by <paramref name="constant"/>.
        /// </summary>
        /// <param name="left">
        /// The array to multiply.
        /// </param>
        /// <param name="constant">
        /// The value to multiply with.
        /// </param>
        /// <returns>
        /// A new array that is the result of multiplying each element in <paramref name="left"/>
        /// with <paramref name="constant"/>.
        /// </returns>
        public static double[] Multiply(double[] left, double constant)
        {
            var result = new double[left.Length];
            for (int i = 0; i < left.Length; ++i)
            {
                result[i] = left[i] * constant;
            }

            return result;
        }

        /// <summary>
        /// Multiplies each element in <paramref name="left"/> by each element in <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The array to multiply.
        /// </param>
        /// <param name="right">
        /// The array to multiply with.
        /// </param>
        /// <returns>
        /// A new array that is the result of multiplying each element in <paramref name="left"/>
        /// with <paramref name="right"/>.
        /// </returns>
        public static double[] Multiply(double[] left, double[] right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Arrays must have same length");
            }

            var result = new double[left.Length];
            for (int i = 0; i < left.Length; ++i)
            {
                result[i] = left[i] * right[i];
            }

            return result;
        }
    }
}

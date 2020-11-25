// <copyright file="BigRational.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System;
    using System.Numerics;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// A <see cref="BigRational"/> that represents a zero value (0).
        /// </summary>
        public static readonly BigRational Zero = BigInteger.Zero;

        /// <summary>
        /// A <see cref="BigRational"/> that represents the value one (1).
        /// </summary>
        public static readonly BigRational One = BigInteger.One;

        /// <summary>
        /// A <see cref="BigRational"/> that represents the value minus one (-1).
        /// </summary>
        public static readonly BigRational MinusOne = BigInteger.MinusOne;

        /// <summary>
        /// A <see cref="BigRational"/> that represents the value 1/2.
        /// </summary>
        public static readonly BigRational Half = new BigRational(1, 2);

        /// <summary>
        /// The denominator value of this <see cref="BigRational"/>.
        /// </summary>
        private readonly BigInteger denominator;

        /// <summary>
        /// The numerator value of this <see cref="BigRational"/>.
        /// </summary>
        private readonly BigInteger numerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BigRational"/> struct.
        /// </summary>
        /// <param name="numerator">
        /// The numerator.
        /// </param>
        /// <param name="denominator">
        /// The denominator.
        /// </param>
        /// <exception cref="DivideByZeroException">
        /// If <paramref name="denominator"/> is zero.
        /// </exception>
        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            if (denominator.IsZero)
            {
                throw new DivideByZeroException("The denominator of a BigRational cannot be zero.");
            }

            if (numerator.IsZero)
            {
                this.numerator = BigInteger.Zero;
                this.denominator = BigInteger.One;
            }
            else
            {
                var gcd = denominator < BigInteger.Zero
                    ? -BigInteger.GreatestCommonDivisor(numerator, denominator)
                    : BigInteger.GreatestCommonDivisor(numerator, denominator);

                this.numerator = numerator / gcd;
                this.denominator = denominator / gcd;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BigRational"/> struct.
        /// </summary>
        /// <param name="numerator">
        /// The numerator.
        /// </param>
        /// <remarks>
        /// Sets the <see cref="Denominator"/> to <see cref="BigInteger.One"/>.
        /// </remarks>
        public BigRational(BigInteger numerator)
        {
            this.numerator = numerator;
            this.denominator = BigInteger.One;
        }

        /// <summary>
        /// Gets the denominator of this <see cref = "BigRational" />.
        /// </summary>
        /// <remarks>
        /// This is currently a computed property because c# does not provide a default constructor.
        /// This ensures that a default constructed <see cref="BigRational"/> is equal to (0 / 1).
        /// </remarks>
        public BigInteger Denominator
        {
            get => this.denominator.IsZero
                ? BigInteger.One
                : this.denominator;
        }

        /// <summary>
        /// Gets the numerator of this <see cref = "BigRational"/>.
        /// </summary>
        public BigInteger Numerator
        {
            get => this.numerator;
        }

        /// <summary>
        /// Gets a number that indicates if <see cref="Numerator"/> is negative, positive, or zero.
        /// </summary>
        /// <returns>
        /// -1 if the value of the numerator is negative,
        /// 0 if the value of the numerator is zero,
        /// 1 if the value of the numerator is positive.
        /// </returns>
        public int Sign
        {
            get => this.Numerator.Sign;
        }

        /// <summary>
        /// Gets a value indicating whether the numerator is positive.
        /// </summary>
        public bool IsPositive
        {
            get => this.Numerator.Sign == 1;
        }

        /// <summary>
        /// Gets a value indicating whether the numerator is negative.
        /// </summary>
        public bool IsNegative
        {
            get => this.Numerator.Sign == -1;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BigRational"/> is equal to zero (0 / 1).
        /// </summary>
        public bool IsZero
        {
            get => this.Numerator.IsZero;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BigRational"/> is equal to one (1/1).
        /// </summary>
        public bool IsOne
        {
            get => this.Numerator.IsOne && this.Denominator.IsOne;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BigRational"/> is equal to minus one (-1/1).
        /// </summary>
        public bool IsMinusOne
        {
            get => this.Numerator == BigInteger.MinusOne && this.Denominator.IsOne;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BigRational"/> can be represented as an integer (x/1).
        /// </summary>
        public bool IsInteger
        {
            get => this.Denominator.IsOne;
        }

        /// <summary>
        /// Deconstructs this <see cref="BigRational"/> into a numerator and a denominator.
        /// </summary>
        /// <param name="numerator">The numerator of this <see cref="BigRational"/>.</param>
        /// <param name="denominator">The denominator of this <see cref="BigRational"/>.</param>
        public void Deconstruct(out BigInteger numerator, out BigInteger denominator)
        {
            numerator = this.Numerator;
            denominator = this.Denominator;
        }
    }
}

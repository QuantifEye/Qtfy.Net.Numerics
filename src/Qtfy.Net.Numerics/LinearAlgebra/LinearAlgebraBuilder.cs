// <copyright file="LinearAlgebraBuilder.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    /// <summary>
    /// The base class to all linear algebra objects.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the object that will be built.
    /// </typeparam>
    public abstract class LinearAlgebraBuilder<TResult>
    {
        /// <summary>
        /// The linear algebra object data.
        /// </summary>
        private protected double[] data;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraBuilder{TResult}"/> class.
        /// </summary>
        /// <param name="data">
        /// The linear algebra object data.
        /// </param>
        private protected LinearAlgebraBuilder(double[] data)
        {
            this.data = data;
        }

        /// <summary>
        /// A method that constructs the desired linear algebra object from the
        /// provided data.
        /// </summary>
        /// <param name="data">
        /// The data to construct the linear algebra object with.
        /// </param>
        /// <returns>
        /// A new linear algebra object.
        /// </returns>
        private protected abstract TResult Factory(double[] data);

        /// <summary>
        /// Builds a new linear algebra object by copying the data from the builder
        /// to the new object leaving the data in the builder in tact.
        /// </summary>
        /// <returns>
        /// A new linear algebra object.
        /// </returns>
        public TResult BuildCopy()
        {
            return this.Factory(this.data.Copy());
        }

        /// <summary>
        /// Builds a new linear algebra object by moving the data from the builder
        /// to the new object and then setting the data in the builder to null.
        /// </summary>
        /// <returns>
        /// A new linear algebra object.
        /// </returns>
        public TResult BuildMove()
        {
            var temp = this.data;
            this.data = default;
            return this.Factory(temp);
        }
    }
}

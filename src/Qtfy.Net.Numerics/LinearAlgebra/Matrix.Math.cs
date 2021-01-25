// <copyright file="Matrix.Math.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    public partial class Matrix
    {
        private static unsafe void VectorMatrixProductImpl(
            double* matrix,
            nint columns,
            double* vector,
            double* vectorEnd,
            double* result,
            double* resultEnd)
        {
            double* v, m;
            double total;
            while (result != resultEnd)
            {
                v = vector;
                m = matrix;
                total = *v * *m;
                while (++v != vectorEnd)
                {
                    m += columns;
                    total += *v * *m;
                }

                *result = total;
                ++matrix;
                ++result;
            }
        }

        private static unsafe void MatrixVectorProductImpl(
            double* matrix,
            double* vector,
            double* vectorEnd,
            double* result,
            double* resultEnd)
        {
            double* v;
            double total;
            do
            {
                v = vector;
                total = *v * *matrix;
                while (++v != vectorEnd)
                {
                    ++matrix;
                    total += *v * *matrix;
                }

                *result = total;
            }
            while (++result != resultEnd);
        }

        private static unsafe double FusedVectorMatrixVectorProductImpl(
            double* left,
            double* leftEnd,
            double* matrix,
            double* right,
            double* rightEnd)
        {
            double total = 0d;
            double temp;
            double* r;
            do
            {
                r = right;
                temp = *matrix * *r;
                ++r;
                ++matrix;
                while (r != rightEnd)
                {
                    temp += *matrix * *r;
                    ++r;
                    ++matrix;
                }

                total += *left * temp;
            }
            while (++left != leftEnd);

            return total;
        }

        private static unsafe double FusedVectorMatrixVectorProductImpl(
            double* leftAndRight,
            double* leftAndRightEnd,
            double* matrix)
        {
            double total = 0d;
            double temp;
            double* l = leftAndRight;
            double* r;
            do
            {
                r = leftAndRight;
                temp = *matrix * *r;
                ++r;
                ++matrix;
                while (r != leftAndRightEnd)
                {
                    temp += *matrix * *r;
                    ++r;
                    ++matrix;
                }

                total += *l * temp;
            }
            while (++l != leftAndRightEnd);

            return total;
        }
    }
}

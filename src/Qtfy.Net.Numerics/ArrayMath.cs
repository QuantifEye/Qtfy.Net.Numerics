// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;

    public static class ArrayMath
    {
        public static double AbsoluteSum(this IEnumerable<double> v)
        {
            return v.Select(Math.Abs).Sum();
        }

        public static double AbsoluteSum(this double[] self)
        {
            var total = 0d;
            for (int i = 0; i < self.Length; i++)
            {
                total += Math.Abs(self[i]);
            }

            return total;
        }

        public static double Sum(this double[] self)
        {
            var total = 0d;
            for (int i = 0; i < self.Length; i++)
            {
                total += self[i];
            }

            return total;
        }

        public static double Max(this double[] self)
        {
            var max = double.NegativeInfinity;
            for (int i = 0; i < self.Length; i++)
            {
                max = Math.Max(max, self[i]);
            }

            return max;
        }

        public static double AbsoluteMax(this double[] self)
        {
            var max = 0d;
            for (int i = 0; i < self.Length; i++)
            {
                var current = Math.Abs(self[i]);
                if (double.IsNaN(current) || current > max)
                {
                    max = current;
                }
            }

            return max;
        }

        public static int AbsoluteMaxIndex(this double[] self)
        {
            if (self.Length == 0)
            {
                throw new ArgumentException();
            }

            var max = 0d;
            int index = 0;
            for (int i = 0; i < self.Length; i++)
            {
                var current = Math.Abs(self[i]);
                if (double.IsNaN(current))
                {
                    return i;
                }
                else if (current > max)
                {
                    max = current;
                    index = i;
                }
            }

            return index;
        }


        public static int AbsoluteMinIndex(this double[] self)
        {
            if (self.Length == 0)
            {
                throw new ArgumentException();
            }

            var max = double.PositiveInfinity;
            int index = 0;
            for (int i = 0; i < self.Length; i++)
            {
                var current = Math.Abs(self[i]);
                if (double.IsNaN(current))
                {
                    return i;
                }
                else if (current < max)
                {
                    max = current;
                    index = i;
                }
            }

            return index;
        }

        public static double InnerProduct(double[] left, double[] right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentNullException();
            }

            var total = 0d;
            for (int i = 0; i < left.Length; i++)
            {
                total += left[i] * right[i];
            }

            return total;
        }

        public static double EuclidianNorm(this double[] self)
        {
            var total = 0d;
            for (int i = 0; i < self.Length; i++)
            {
                var temp = self[i];
                total += temp * temp;
            }

            return Math.Sqrt(total);
        }

        public static void ScaleInplace(this double[] self, double scalar)
        {
            for (int i = 0; i < self.Length; i++)
            {
                self[i] *= scalar;
            }
        }

        public static double[] Scale(this double[] self, double scalar)
        {
            var result = new double[self.Length];
            result.ScaleInplace(scalar);
            return result;
        }
    }
}

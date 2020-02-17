// <copyright file="Data.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Data
    {
        public const int Size = 6;

        private static IEnumerable<(int n, int d)> AllPairs()
        {
            for (var n = -Size; n <= Size; n++)
            {
                for (var d = 1; d <= Size; d++)
                {
                    yield return (n, d);
                    yield return (n, -d);
                }
            }
        }

        private static IEnumerator<object[]> AllWhere(Func<int, int, bool> predicate)
        {
            foreach (var (n, d) in AllPairs())
            {
                if (predicate(n, d))
                {
                    yield return new object[] { n, d };
                }
            }
        }

        public class IsIntegerCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                return AllWhere((n, d) => (n / (double)d) == (n / d));
            }
        }

        public class NotIntegerCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                return AllWhere((n, d) => (n / (double)d) != (n / d));
            }
        }

        public class IsOneCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                return AllWhere((n, d) => n == d);
            }
        }

        public class NotOneCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                return AllWhere((n, d) => n != d);
            }
        }

        public class NotMinusOneCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                return AllWhere((n, d) => n != -d);
            }
        }

        public class IsMinusOneCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                return AllWhere((n, d) => n == -d);
            }
        }

        public class AllCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                foreach (var (n, d) in AllPairs())
                {
                    yield return new object[] { n, d };
                }
            }
        }

        public class ZeroCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                for (var d = 1; d <= Size; d++)
                {
                    yield return new object[] { 0, d };
                    yield return new object[] { 0, -d };
                }
            }
        }

        public class PositiveCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                for (var n = 1; n <= Size; n++)
                {
                    for (var d = 1; d <= Size; d++)
                    {
                        yield return new object[] { n, d };
                        yield return new object[] { -n, -d };
                    }
                }
            }
        }

        public class NegativeCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                for (var n = 1; n <= Size; n++)
                {
                    for (var d = 1; d <= Size; d++)
                    {
                        yield return new object[] { n, -d };
                        yield return new object[] { -n, d };
                    }
                }
            }
        }
    }
}

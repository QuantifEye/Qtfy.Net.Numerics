// <copyright file="PowerSetTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.CombinatoricsTests
{
    using System.Linq;
    using NUnit.Framework;

    public class PowerSetTests
    {
        private static readonly (int[] left, int[] right)[] Expected =
        {
            (new int[] { }, new[] { 1, 2, 3 }),
            (new[] { 1 }, new[] { 2, 3 }),
            (new[] { 2 }, new[] { 1, 3 }),
            (new[] { 1, 2 }, new[] { 3 }),
            (new[] { 3 }, new[] { 1, 2 }),
            (new[] { 1, 3 }, new[] { 2 }),
            (new[] { 2, 3 }, new[] { 1 }),
            (new[] { 1, 2, 3 }, new int[] { }),
        };

        [Test]
        public void PowerSetTest()
        {
            int[] source = { 1, 2, 3 };
            var actual = Combinatorics.PowerSet(source).ToArray();
            var expected = Expected.Select(x => x.left).ToArray();
            Assert.AreEqual(actual.Length, Expected.Length);
            for (var i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(Expected[i].left.AsEnumerable(), actual[i].AsEnumerable());
            }
        }

        [Test]
        public void PowerSetWithComplimentTest()
        {
            int[] source = { 1, 2, 3 };
            var actual = Combinatorics.PowerSetWithCompliment(source).ToArray();
            var expected = Expected.Select(x => x.left).ToArray();
            Assert.AreEqual(actual.Length, Expected.Length);
            for (var i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(Expected[i].left.AsEnumerable(), actual[i].left.AsEnumerable());
                Assert.AreEqual(Expected[i].right.AsEnumerable(), actual[i].right.AsEnumerable());
            }
        }

        [Test]
        public void PowerSetEmptyTest()
        {
            int[] source = { };
            var actual = Combinatorics.PowerSet(source).ToArray();
            Assert.AreEqual(1, actual.Length);
            var empty = actual[0];
            Assert.AreEqual(0, empty.Length);
        }
    }
}

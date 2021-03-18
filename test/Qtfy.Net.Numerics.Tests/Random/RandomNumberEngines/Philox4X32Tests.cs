// <copyright file="Philox4X32Tests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.RandomNumberEngines
{
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random.RandomNumberEngines;

    public class Philox4X32Tests
    {
        [Test]
        public void TestFirstBuffer()
        {
            var engine = new Philox4X32(0, 0);
            var actual = new uint[4];
            for (int i = 0; i < actual.Length; ++i)
            {
                actual[i] = engine.NextUInt();
            }

            var expected = new uint[]
            {
                0x6627e8d5,
                0xe169c58d,
                0xbc57ac4c,
                0x9b00dbd8,
            };

            Assert.AreEqual(expected, actual);
        }
    }
}

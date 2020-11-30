﻿// <copyright file="BigRationalTests.Serialization.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        public void SerialiseValid(int n, int d)
        {
            // var expected = new BigRational(n, d);
            // BigRational actual;
            // IFormatter formatter = new BinaryFormatter(); // deprecated
            // using (var stream = new MemoryStream())
            // {
            //     formatter.Serialize(stream, expected);
            //     using (var resultStream = new MemoryStream(stream.ToArray()))
            //     {
            //         actual = (BigRational)formatter.Deserialize(resultStream);
            //     }
            // }
            // Assert.AreEqual(expected, actual);
            Assert.Fail();
        }

        [TestCase(1, 2)]
        public void TestXmlSerialise(int n, int d)
        {
            var rational = new BigRational(n, d);
            var serializer = new XmlSerializer(typeof(BigRational));
            var num = rational.Numerator;
            var den = rational.Denominator;
            var nl = Environment.NewLine;
            var expected = $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{nl}<BigRational>{num}/{den}</BigRational>";
            string actual;
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                serializer.Serialize(streamWriter, rational);
                actual = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2)]
        public void TestXmlDeserialize(int n, int d)
        {
            var expected = new BigRational(n, d);
            var serializer = new XmlSerializer(typeof(BigRational));
            var text = $"<BigRational>{expected.Numerator}/{expected.Denominator}</BigRational>";
            using var textReader = new StringReader(text);
            using var reader = XmlReader.Create(textReader);
            var actual = (BigRational)serializer.Deserialize(reader);
            Assert.AreEqual(expected, actual);
        }
    }
}

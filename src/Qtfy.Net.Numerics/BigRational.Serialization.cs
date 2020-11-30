// <copyright file="BigRational.Serialization.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    using System;
    using System.Numerics;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    [Serializable]
    public partial struct BigRational : ISerializable, IXmlSerializable
    {
        /// <summary>
        /// The name used for the numerator field for binary serialization.
        /// </summary>
        /// <remarks>
        /// Do not change as this will break binary serialization.
        /// </remarks>
        private const string NumeratorName = "n";

        /// <summary>
        /// The name used for the denominator field for binary serialization.
        /// </summary>
        /// <remarks>
        /// Do not change as this will break binary serialization.
        /// </remarks>
        private const string DenominatorName = "d";

        /// <summary>
        /// Initializes a new instance of the <see cref="BigRational"/> struct.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        /// <exception cref="SerializationException">
        /// If the deserialized Numerator is less than or equal to zero,
        /// or if the deserialized numerator and denominator are not co-prime.
        /// </exception>
        private BigRational(SerializationInfo info, StreamingContext context)
        {
            var numeratorValue = (BigInteger)info.GetValue(NumeratorName, typeof(BigInteger));
            var denominatorValue = (BigInteger)info.GetValue(DenominatorName, typeof(BigInteger));

            if (denominatorValue <= 0)
            {
                throw new SerializationException("Invalid denominator, denominator must positive.");
            }

            if (!BigInteger.GreatestCommonDivisor(numeratorValue, denominatorValue).IsOne)
            {
                throw new SerializationException(
                    "Invalid rational representation. Numerator and denominator must be coprime.");
            }

            this.numerator = numeratorValue;
            this.denominator = denominatorValue;
        }

        /// <inheritdoc/>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(NumeratorName, this.Numerator);
            info.AddValue(DenominatorName, this.Denominator);
        }

                /// <inheritdoc/>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <inheritdoc/>
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            this = Parse(reader.ReadContentAsString());
            reader.ReadEndElement();
        }

        /// <inheritdoc/>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteValue(this.ToString());
        }
    }
}
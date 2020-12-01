// <copyright file="BigRational.Serialization.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational : IXmlSerializable
    {
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
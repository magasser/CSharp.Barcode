using System;

using CSharp.Barcode.Encoders;

namespace CSharp.Barcode
{
    internal sealed class ECIEncoder : IQREncoder
    {
        /// <inheritdoc />
        public QREncodingMode EncodingMode { get; } = QREncodingMode.ECI;

        /// <inheritdoc />
        public string Encode(string payload, QRVersion version) => throw new NotImplementedException();
    }
}

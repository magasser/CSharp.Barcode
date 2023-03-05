using System;
using System.Text;

using CSharp.Barcode.Exceptions;
using CSharp.Barcode.Extensions;
using CSharp.Barcode.Utils;

namespace CSharp.Barcode.Encoders
{
    internal sealed class ByteEncoder : IQREncoder
    {
        private static readonly Encoding ISO8859_1 = Encoding.GetEncoding("ISO-8859-1");

        /// <inheritdoc />
        public QREncodingMode EncodingMode { get; } = QREncodingMode.Byte;

        /// <inheritdoc />
        public string Encode(string payload, QRVersion version)
        {
            if (payload is null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            if (version is null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            var modeIndicator = EncodingMode.GetModeIndicator(version)
                             ?? throw new EncodingException(
                                    $"Cannot encode payload with encoding mode '{EncodingMode}' in version '{version}'.");

            var characterCountIndicator = EncoderHelper.ToBinary(
                payload.Length.ToString(),
                length: version.ByteCharacterCountBits
                     ?? throw new EncodingException(
                            $"Cannot encode payload with encoding mode '{EncodingMode}' in version '{version}'."));

            var bytes = ISO8859_1.GetBytes(payload);

            var dataBinary = EncoderHelper.ToBinary(bytes);

            return string.Format("{0}{1}{2}", modeIndicator, characterCountIndicator, dataBinary);
        }
    }
}

using System;
using System.Linq;

using CSharp.Barcode.Exceptions;
using CSharp.Barcode.Extensions;
using CSharp.Barcode.Utils;

namespace CSharp.Barcode.Encoders
{
    internal sealed class NumericEncoder : IQREncoder
    {
        /// <inheritdoc />
        public QREncodingMode EncodingMode { get; } = QREncodingMode.Numeric;

        /// <inheritdoc />
        public string Encode(string payload, QRVersion version)
        {
            const int chunkSize = 3;

            if (version is null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            if (payload is null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            if (payload.Length != 0 && !EncoderHelper.IsNumeric(payload))
            {
                throw new ArgumentException("Value must be numeric string.", nameof(payload));
            }

            var modeIndicator = EncodingMode.GetModeIndicator(version)
                             ?? throw new EncodingException(
                                    $"Cannot encode payload with encoding mode '{EncodingMode}' in version '{version}'.");

            var characterCountIndicator = EncoderHelper.ToBinary(
                payload.Length.ToString(),
                length: version.NumericCharacterCountBits);

            var chunks = EncoderHelper.ChunkMax(payload, chunkSize);

            var binaryStrings = chunks.Select(
                chunk =>
                    chunk.Length switch
                    {
                        1 => EncoderHelper.ToBinary(chunk, length: 4),
                        2 => EncoderHelper.ToBinary(chunk, length: 7),
                        3 => EncoderHelper.ToBinary(chunk, length: 10),
                        _ => throw new InvalidOperationException("The chunk size must be in range [1;3].")
                    });

            var dataBinary = string.Join(separator: string.Empty, binaryStrings);

            return string.Format("{0}{1}{2}", modeIndicator, characterCountIndicator, dataBinary);
        }
    }
}

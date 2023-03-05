using System;
using System.Collections.Generic;
using System.Linq;

using CSharp.Barcode.Exceptions;
using CSharp.Barcode.Extensions;
using CSharp.Barcode.Utils;

namespace CSharp.Barcode.Encoders
{
    internal sealed class AlphanumericEncoder : IQREncoder
    {
        /// <inheritdoc />
        public QREncodingMode EncodingMode { get; } = QREncodingMode.Alphanumeric;

        private static IDictionary<char, int> EncodingTable =>
            new Dictionary<char, int>
            {
                { '0', 0 },
                { '1', 1 },
                { '2', 2 },
                { '3', 3 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 7 },
                { '8', 8 },
                { '9', 9 },
                { 'A', 10 },
                { 'B', 11 },
                { 'C', 12 },
                { 'D', 13 },
                { 'E', 14 },
                { 'F', 15 },
                { 'G', 16 },
                { 'H', 17 },
                { 'I', 18 },
                { 'J', 19 },
                { 'K', 20 },
                { 'L', 21 },
                { 'M', 22 },
                { 'N', 23 },
                { 'O', 24 },
                { 'P', 25 },
                { 'Q', 26 },
                { 'R', 27 },
                { 'S', 28 },
                { 'T', 29 },
                { 'U', 30 },
                { 'V', 31 },
                { 'W', 32 },
                { 'X', 33 },
                { 'Y', 34 },
                { 'Z', 35 },
                { ' ', 36 },
                { '$', 37 },
                { '%', 38 },
                { '*', 39 },
                { '+', 40 },
                { '-', 41 },
                { '.', 42 },
                { '/', 43 },
                { ':', 44 }
            };

        /// <inheritdoc />
        public string Encode(string payload, QRVersion version)
        {
            const int chunkSize = 2;

            if (payload is null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            if (version is null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            if (payload.Length != 0 && payload.Any(c => !EncodingTable.ContainsKey(c)))
            {
                throw new ArgumentException("Value must be alphanumeric string.", nameof(payload));
            }

            var modeIndicator = EncodingMode.GetModeIndicator(version)
                             ?? throw new EncodingException(
                                    $"Cannot encode payload with encoding mode '{EncodingMode}' in version '{version}'.");
            ;

            var characterCountIndicator = EncoderHelper.ToBinary(
                payload.Length.ToString(),
                length: version.AlphanumericCharacterCountBits
                     ?? throw new EncodingException(
                            $"Cannot encode payload with encoding mode '{EncodingMode}' in version '{version}'."));

            var binaryStrings = EncoderHelper.ChunkMax(payload, chunkSize)
                                             .Select(
                                                 chunk =>
                                                     chunk.Length switch
                                                     {
                                                         1 => EncoderHelper.ToBinary(
                                                             EncodingTable[chunk[0]].ToString(),
                                                             length: 6),
                                                         2 => EncoderHelper.ToBinary(
                                                             (EncodingTable[chunk[0]] * 45 + EncodingTable[chunk[1]])
                                                             .ToString(),
                                                             length: 11),
                                                         _ => throw new InvalidOperationException(
                                                                  "The chunk size must be in range [1;2].")
                                                     });

            var dataBinary = string.Join(separator: string.Empty, binaryStrings);

            return string.Format("{0}{1}{2}", modeIndicator, characterCountIndicator, dataBinary);
        }
    }
}

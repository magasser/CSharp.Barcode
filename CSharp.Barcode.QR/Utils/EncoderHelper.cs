using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CSharp.Barcode.Utils
{
    internal static class EncoderHelper
    {
        /// <summary>
        ///     Determines if the <paramref name="source" /> string is numeric.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if the <paramref name="source" /> is numeric, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsNumeric(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }

            foreach (var c in source)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Creates chunks with a size of <paramref name="maxChunkSize" /> from the <paramref name="source" /> string.
        ///     If the length of the string is not divisible by the <paramref name="maxChunkSize" /> the last
        ///     chunk will be smaller.
        /// </summary>
        /// <param name="source">The source string of which to create the chunks.</param>
        /// <param name="maxChunkSize">The maximum chunk size.</param>
        /// <returns>Returns the chunks in a list of strings.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IReadOnlyList<string> ChunkMax(string source, int maxChunkSize)
        {
            if (maxChunkSize <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(maxChunkSize),
                    "The maximum chunk size must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                return Array.Empty<string>();
            }

            return chunk(source, maxChunkSize).ToList();

            IEnumerable<string> chunk(string value, int size)
            {
                for (var i = 0; i < value.Length; i += size)
                {
                    yield return value.Substring(i, Math.Min(size, value.Length - i));
                }
            }
        }

        /// <summary>
        ///     Converts the <paramref name="source" /> string into a binary string.
        /// </summary>
        /// <param name="source">The source string to convert.</param>
        /// <returns>Returns the converted binary string.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ToBinary(string source)
        {
            if (!IsNumeric(source))
            {
                throw new ArgumentException("Value must be numeric string.", nameof(source));
            }

            var builder = ToBinaryBuilder(source);

            return builder.ToString();
        }

        /// <summary>
        /// Converts the <paramref name="source" /> string into a binary string of given <paramref name="length"/>.
        /// </summary>
        /// <param name="source">The source string to convert.</param>
        /// <param name="length">The length of the resulting binary string</param>
        /// <returns>Returns the converted binary string.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ToBinary(string source, int length)
        {
            if (!IsNumeric(source))
            {
                throw new ArgumentException("Value must be numeric string.", nameof(source));
            }

            var builder = ToBinaryBuilder(source);

            if (builder.Length < length)
            {
                builder.Insert(index: 0, new string('0', count: length - builder.Length));
            }
            else if (builder.Length > length)
            {
                builder.Remove(startIndex: 0, length: builder.Length - length);
            }

            return builder.ToString();
        }

        private static StringBuilder ToBinaryBuilder(string source)
        {
            var bytes = BigInteger.Parse(source)
                                  .ToByteArray();

            var builder = new StringBuilder(capacity: bytes.Length * 8);

            for (var i = bytes.Length - 1; i >= 0; i--)
            {
                builder.Append(Convert.ToString(bytes[i], toBase: 2).PadLeft(8, '0'));
            }

            return builder;
        }
    }
}

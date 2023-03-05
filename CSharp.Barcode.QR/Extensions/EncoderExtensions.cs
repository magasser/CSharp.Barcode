using System;
using System.ComponentModel;

namespace CSharp.Barcode.Extensions
{
    internal static class EncoderExtensions
    {
        public static string? GetModeIndicator(this QREncodingMode mode, QRVersion version)
        {
            if (version is null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            if (!Enum.IsDefined(typeof(QREncodingMode), mode))
            {
                throw new InvalidEnumArgumentException(nameof(mode), (int)mode, typeof(QREncodingMode));
            }

            return version switch
            {
                var _ when version == QRVersion.VersionM1 => null,
                var _ when version == QRVersion.VersionM2 => mode switch
                {
                    QREncodingMode.Numeric => "0",
                    QREncodingMode.Alphanumeric => "1",
                    _ => null
                },
                var _ when version == QRVersion.VersionM3 => mode switch
                {
                    QREncodingMode.Numeric => "00",
                    QREncodingMode.Alphanumeric => "01",
                    QREncodingMode.Byte => "10",
                    QREncodingMode.Kanji => "11",
                    _ => null
                },
                var _ when version == QRVersion.VersionM4 => mode switch
                {
                    QREncodingMode.Numeric => "000",
                    QREncodingMode.Alphanumeric => "001",
                    QREncodingMode.Byte => "010",
                    QREncodingMode.Kanji => "011",
                    _ => null
                },
                _ => mode switch
                {
                    QREncodingMode.ECI => "0111",
                    QREncodingMode.Numeric => "0001",
                    QREncodingMode.Alphanumeric => "0010",
                    QREncodingMode.Byte => "0100",
                    QREncodingMode.Kanji => "1000",
                    QREncodingMode.StructuredAppend => "0011",

                    // TODO: Handle the FNC1 encoding mode
                    QREncodingMode.FNC1 => throw new NotImplementedException(),
                    _ => null
                }
            };
        }
    }
}

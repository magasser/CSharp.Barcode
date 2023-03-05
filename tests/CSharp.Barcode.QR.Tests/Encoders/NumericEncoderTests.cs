using CSharp.Barcode.Encoders;

namespace CSharp.Barcode.QR.Tests.Encoders;

public class NumericEncoderTests
{
    public static IEnumerable<object[]> EncodeInvalidArgumentsData =>
        new List<object[]>
        {
            new object[] { null, QRVersion.Version1, typeof(ArgumentNullException) },
            new object[] { "  ", QRVersion.Version1, typeof(ArgumentException) },
            new object[] { "12a", QRVersion.Version1, typeof(ArgumentException) },
            new object[] { "123", null, typeof(ArgumentNullException) },
            new object[] { "123", null, typeof(ArgumentNullException) }
        };

    public static IEnumerable<object[]> EncodeData =>
        new List<object[]>
        {
            new object[] { "", QRVersion.Version1, "00010000000000" },
            new object[] { "123", QRVersion.Version1, "000100000000110001111011" },
            new object[] { "01234567", QRVersion.Version1, "00010000001000000000110001010110011000011" },
            new object[]
            {
                "0123456789012345",
                QRVersion.VersionM3,
                "0010000000000110001010110011010100110111000010100111010100101"
            }
        };

    [Theory]
    [MemberData(nameof(EncodeInvalidArgumentsData))]
    public void Encode_throws_with_invalid_arguments(string payload, QRVersion version, Type exceptionType)
    {
        // Arrange
        var subject = new NumericEncoder();

        // Act
        var act = () => subject.Encode(payload, version);

        // Assert
        Assert.Throws(exceptionType, act);
    }

    [Theory]
    [MemberData(nameof(EncodeData))]
    public void Encode_returns_correct_binary_string(string payload, QRVersion version, string expected)
    {
        // Arrange
        var subject = new NumericEncoder();

        // Act
        var result = subject.Encode(payload, version);

        // Assert
        Assert.Equal(expected, result);
    }
}

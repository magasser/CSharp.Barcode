using CSharp.Barcode.Encoders;

namespace CSharp.Barcode.QR.Tests.Encoders;

public class ByteEncoderTests
{
    public static IEnumerable<object[]> EncodeInvalidArgumentsData =>
        new List<object[]>
        {
            new object[] { null, QRVersion.Version1, typeof(ArgumentNullException) },
            new object[] { "", null, typeof(ArgumentNullException) }
        };

    public static IEnumerable<object[]> EncodeData =>
        new List<object[]>
        {
            new object[] { "", QRVersion.Version1, "010000000000" },
            new object[] { "abc", QRVersion.Version1, "010000000011011000010110001001100011" },
            new object[] { "¿¶µ®", QRVersion.Version1, "01000000010010111111101101101011010110101110" }
        };

    [Theory]
    [MemberData(nameof(EncodeInvalidArgumentsData))]
    public void Encode_throws_with_invalid_arguments(string payload, QRVersion version, Type exceptionType)
    {
        // Arrange
        var subject = new ByteEncoder();

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
        var subject = new ByteEncoder();

        // Act
        var result = subject.Encode(payload, version);

        // Assert
        Assert.Equal(expected, result);
    }
}

using CSharp.Barcode.Encoders;

namespace CSharp.Barcode.QR.Tests.Encoders;

public class AlphanumericEncoderTests
{
    public static IEnumerable<object[]> EncodeInvalidArgumentsData =>
        new List<object[]>
        {
            new object[] { null, QRVersion.Version1, typeof(ArgumentNullException) },
            new object[] { "12£", QRVersion.Version1, typeof(ArgumentException) },
            new object[] { "ABC", null, typeof(ArgumentNullException) },
            new object[] { "ABC", null, typeof(ArgumentNullException) }
        };

    public static IEnumerable<object[]> EncodeData =>
        new List<object[]>
        {
            new object[] { "", QRVersion.Version1, "0010000000000" },
            new object[]
            {
                "NM$%./:+-",
                QRVersion.Version1,
                "001000000100110000100001110101001111111000110111111100100101001"
            },
            new object[] { "AC-42", QRVersion.Version1, "00100000001010011100111011100111001000010" }
        };

    [Theory]
    [MemberData(nameof(EncodeInvalidArgumentsData))]
    public void Encode_throws_with_invalid_arguments(string payload, QRVersion version, Type exceptionType)
    {
        // Arrange
        var subject = new AlphanumericEncoder();

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
        var subject = new AlphanumericEncoder();

        // Act
        var result = subject.Encode(payload, version);

        // Assert
        Assert.Equal(expected, result);
    }
}

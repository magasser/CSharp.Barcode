using CSharp.Barcode.Utils;

namespace CSharp.Barcode.QR.Tests.Utils;

public class StringHelperTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("abc")]
    [InlineData("ABC123DEF456")]
    public void IsNumeric_returns_false_for_non_numeric_strings(string source)
    {
        // Act
        var result = EncoderHelper.IsNumeric(source);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("123")]
    [InlineData("1234567890")]
    public void IsNumeric_returns_true_for_numeric_strings(string source)
    {
        // Act
        var result = EncoderHelper.IsNumeric(source);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(-1)]
    [InlineData(0)]
    public void ChunkMax_throws_when_invalid_max_chunk_size(int maxChunkSize)
    {
        // Act
        var act = () => EncoderHelper.ChunkMax(source: "test", maxChunkSize);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void ChunkMax_returns_empty_list_when_null_or_whitespace_source(string source)
    {
        // Act
        var result = EncoderHelper.ChunkMax(source, maxChunkSize: 1);

        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("a", 3, new[] { "a" })]
    [InlineData("abcdefghi", 3, new[] { "abc", "def", "ghi" })]
    [InlineData("abcdefghi", 2, new[] { "ab", "cd", "ef", "gh", "i" })]
    public void ChunkMax_returns_chunks_of_given_size(string source, int maxChunkSize, IReadOnlyList<string> expected)
    {
        // Act
        var result = EncoderHelper.ChunkMax(source, maxChunkSize);

        // Assert
        Assert.Equivalent(expected, result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("abc")]
    [InlineData("ABC123DEF456")]
    public void ToBinary_throws_if_non_numeric_string(string source)
    {
        // Act
        var act = () => EncoderHelper.ToBinary(source);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData("0", "00000000")]
    [InlineData("012", "00001100")]
    [InlineData("345", "0000000101011001")]
    [InlineData("67", "01000011")]
    [InlineData("8", "00001000")]
    public void ToBinary_returns_binary_string(string source, string expected)
    {
        // Act
        var result = EncoderHelper.ToBinary(source);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", 1, "0")]
    [InlineData("012", 10, "0000001100")]
    [InlineData("345", 5, "11001")]
    [InlineData("67", 2, "11")]
    [InlineData("8", 15, "000000000001000")]
    public void ToBinary_returns_binary_string_of_given_length(string source, int length, string expected)
    {
        // Act
        var result = EncoderHelper.ToBinary(source, length);

        // Assert
        Assert.Equal(expected, result);
    }
}

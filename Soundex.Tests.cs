using Xunit;

public class SoundexTests
{
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
    }

    [Theory]
    [InlineData("Washington", "W252")]
    [InlineData("DeSmet", "D253")]
    [InlineData("Gutierrez", "G362")]
    [InlineData("Pfister", "P123")]
    [InlineData("Jackson", "J250")]
    [InlineData("Tymczak", "T522")]
    [InlineData("Ashcraft", "A261")]
    [InlineData("Hanselmann", "H524")]
    public void HandleWords(string word, string soundex)
    {
        Assert.Equal(soundex, Soundex.GenerateSoundex(word));
    }
}

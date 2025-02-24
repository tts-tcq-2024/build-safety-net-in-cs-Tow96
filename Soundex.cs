using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name)) return string.Empty;

        StringBuilder soundex = new();

        // Initiates the soundex by appending the first letter
        soundex.Append(char.ToUpper(name[0]));

        // Goes through the characters appending codes until it is 4 characters long,
        // or it has gone through all characters in string
        for (var i = 1; i < name.Length; i++)
        {
            var code = GetSoundexCode(name[i]);
            soundex = AppendCodeToSoundex(soundex, code);

            if (soundex.Length == 4 && soundex[^1] != '7') break;
        }

        soundex = PadSoundex(soundex);

        return soundex.ToString();
    }

    /// <summary>
    /// Assigns a number to a letter following the soundex system
    /// If zero it means it is a discarded letter
    /// </summary>
    /// <param name="c">character to be coded</param>
    /// <returns>A number from 0 to 7</returns>
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        switch (c)
        {
            case 'B':
            case 'F':
            case 'P':
            case 'V':
                return '1';
            case 'C':
            case 'G':
            case 'J':
            case 'K':
            case 'Q':
            case 'S':
            case 'X':
            case 'Z':
                return '2';
            case 'D':
            case 'T':
                return '3';
            case 'L':
                return '4';
            case 'M':
            case 'N':
                return '5';
            case 'R':
                return '6';
            case 'A':
            case 'E':
            case 'I':
            case 'O':
            case 'U':
                return '7';
            default:
                return '0'; // For H W Y
        }
    }

    private static StringBuilder AppendCodeToSoundex(StringBuilder soundex, char c)
    {
        var previous = soundex[^1];

        // If same code as previous, return nothing
        if (previous == c || c == '0') return soundex;

        switch (previous)
        {
            // If previous was vowel, replace with whatever comes next
            case '7':
                soundex.Remove(soundex.Length - 1, 1);
                soundex.Append(c);
                return soundex;
            default:
                if (previous != c) soundex.Append(c);
                return soundex;
        }
    }

    /// <summary>
    /// Makes the string be 4 characters long by adding zeros
    /// </summary>
    /// <param name="code">A string</param>
    /// <returns>A 4 character string builder</returns>
    private static StringBuilder PadSoundex(StringBuilder code)
    {
        while (code.Length < 4) code.Append('0');
        return code;
    }
}

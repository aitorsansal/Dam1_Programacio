using System.Text;

internal class Program
{
    public static void Main(string[] args)
    {
        
    }

    static bool IsNull(string? data)
    {
        return data == null;
    }

    static int Occurences(string data, char target)
    {
        if (IsNull(data)) throw new Exception("String is null");
        int timesFound = 0;
        foreach (var letter in data)
        {
            if (letter == target) timesFound++;
        }

        return timesFound;
    }
    
    static bool Contains(string data, char target)
    {
        if (IsNull(data)) throw new Exception("String is null");
        bool found = false;
        int i = 0;
        while (++i < data.Length && !found)
        {
            if (data[i] == target) found = true;
        }

        return found;
    }

    static List<int>? Wherels(string data, char target)
    {
        if (IsNull(data)) throw new Exception("String is null");
        List<int>? indexes = new();
        for (var i = 0; i < data.Length; i++)
        {
            if(data[i] == target) indexes.Add(i);
        }

        return indexes.Count > 0 ? indexes : null;
    }

    static string Reverse(string data)
    {
        if (IsNull(data)) throw new Exception("String is null");
        var dataLetters = data.ToList();
        StringBuilder sb = new();
        for (int i = dataLetters.Count - 1; i >= 0; i--)
        {
            sb.Append(dataLetters[i]);
        }
        return sb.ToString();
    }
    
    //Is palindrome
    
    
    //Is palindrome without blanks

    static string ToUpper(string data)
    {
        //-32
        if (IsNull(data)) throw new Exception("String is null");
        StringBuilder sb = new();
        foreach (var letter in data)
        {
            if (letter is >= 'A' and <= 'Z') sb.Append(letter);
            else if (letter is >= 'a' and <= 'z') sb.Append((char)(letter - 32));
            else sb.Append('?');
        }

        return sb.ToString();
    }

    static bool NoLetters(string data)
    {
        if (IsNull(data)) throw new Exception("String is null");
        bool hasLetter = false;
        int i = 0;
        while (++i < data.Length && !hasLetter)
        {
            hasLetter = data[i] >= 'a' && data[i] <= 'z' || data[i] >= 'A' && data[i] <= 'Z';
        }

        return !hasLetter;
    }
}
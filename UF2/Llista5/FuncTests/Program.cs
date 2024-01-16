using System.Text;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(GreaterThan("Be", "Anna"));
        Console.WriteLine(GreaterThan("be", "Anna"));
        Console.WriteLine(GreaterThan("Salat", "Sal"));
        Console.WriteLine(GreaterThan("Sal", "Salat"));
        Console.WriteLine(GreaterThan("Anna", "anna"));
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

    static bool IsPalindrome(string data)
    {
        int start = 0, end = data.Length - 1;
        bool isPalindrome = true;
        while (start < end && isPalindrome)
        {
            if (data[start] != data[end]) isPalindrome = false;
            else
            {
                start++;
                end--;
            }
        }

        return false;
    }


    static bool IsPalindromeWithoutBlanks(string data)
    {
        var splitted = data.Split(" ");
        StringBuilder sb = new();
        foreach (var split in splitted)
        {
            sb.Append(split);
        }

        return IsPalindrome(sb.ToString());
    }

    static string ToUpper(string data)
    {
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
        while (i < data.Length && !hasLetter)
        {
            hasLetter = data[i] >= 'a' && data[i] <= 'z' || data[i] >= 'A' && data[i] <= 'Z';
            i++;
        }

        return !hasLetter;
    }

    static bool GreaterThan(string first, string second)
    {
        if (IsNull(first) || IsNull(second)) throw new Exception("One of the two strings is null");
        bool isGreater = false, isDifferent = false;
        int i = 0;
        if (first.Length > second.Length || first.Length < second.Length)
        {
            isDifferent = true;
        }
        while (i < first.Length && i < second.Length && !isGreater)
        {
            var tempFirst = first[i];
            var tempSecond = second[i];
            if (first[i] > 'Z') tempFirst = (char)(first[i] - 32);
            if (second[i] > 'Z') tempSecond = (char)(second[i] - 32);
            if (tempSecond != tempFirst)
            {
                isGreater = tempFirst > tempSecond;
            }
            i++;
        }
        if(!isGreater && isDifferent)
            isGreater = first.Length > second.Length;
        return isGreater;
    }
}
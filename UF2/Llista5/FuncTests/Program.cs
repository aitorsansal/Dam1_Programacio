using System.Runtime.ExceptionServices;
using System.Text;

internal class Program
{
    private const string FILE_NAME = "paraules.txt";
    private const string STUDENTS_FILE_NAME = "students.txt";
    public static void Main(string[] args)
    {
        //var paraules = GetPalindromWords(FILE_NAME);
        //foreach (var paraula in paraules)
        //{
        //    Console.WriteLine(paraula);
        //}

        //var list = new List<int>() { 1, 5, 3, 2, 5, 7, 1, 2, 5, 4, 8, 3, 2, 1, 9, 8, 4, 1, 3, 5, 48, 6 };
        //var newList = EraseRepeated(list);
        //foreach (var num in newList)
        //{
        //    Console.WriteLine(num);
        //}
        //var students = ReturnStudentsHighOfEight(STUDENTS_FILE_NAME);
        //foreach (var student in students)
        //{
        //    Console.WriteLine(student);
        //}
        ReturnCodeAndAverage(STUDENTS_FILE_NAME);
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
        bool isGreater = false, isDifferent = false, hasDiffChar = false;
        int i = 0;
        if (first.Length > second.Length || first.Length < second.Length)
        {
            isDifferent = true;
        }
        while (i < first.Length && i < second.Length && !isGreater && !hasDiffChar)
        {
            var tempFirst = first[i];
            var tempSecond = second[i];
            if (first[i] > 'Z') tempFirst = (char)(first[i] - 32);
            if (second[i] > 'Z') tempSecond = (char)(second[i] - 32);
            if (tempSecond != tempFirst)
            {
                if (tempFirst > tempSecond)
                    isGreater = true;
                else
                    hasDiffChar = true;
            }
            i++;
        }
        if(!isGreater && isDifferent && !hasDiffChar)
            isGreater = first.Length > second.Length;
        return isGreater;
    }

    #region Extra Exercises

    static List<string> GetPalindromWords(string fileName)
    {
        var paraules = new List<string>();
        StreamReader sr = new(fileName);
        string? linia = sr.ReadLine();
        while (linia != null)
        {
            if(IsPalindrome(linia)) paraules.Add(linia);
            linia = sr.ReadLine();
        }
        return paraules;
    }

    static List<int> EraseRepeated(List<int> toFetch)
    {
        var newNums = new List<int>() { toFetch[0] };
        for (int i = 1; i < toFetch.Count; i++)
        {
            bool isRepeated = false;
            int j = 0;
            while (!isRepeated && j < newNums.Count)
            {
                if (toFetch[i] == newNums[j]) isRepeated = true;
                else j++;
            }
            if(!isRepeated) newNums.Add(toFetch[i]);
        }

        return newNums;
    }

    static List<int> ReturnStudentsHighOfEight(string fileName)
    {
        var studentCodes = new List<int>();
        using (StreamReader sr = new(fileName))
        {
            string? line = sr.ReadLine();
            while (line != null)
            {
                var splitted = line.Split(',');
                var mathScore = Convert.ToInt32(splitted[3]);
                var scienceScore = Convert.ToInt32(splitted[4]);
                var languageScore = Convert.ToInt32(splitted[5]);
                if (mathScore >= 8 && scienceScore >= 8 && languageScore >= 8)
                    studentCodes.Add(Convert.ToInt32(splitted[0]));
                line = sr.ReadLine();
            }
        }

        return studentCodes;
    }

    static int[,] ReturnCodeAndAverage(string fileName)
    {
        int[,] newMatrix;
        using (StreamReader sr = new StreamReader(fileName))
        {
            var wholeText = sr.ReadToEnd();
            var quantityOfLines = wholeText.Split("\n").Length;
            newMatrix = new int[quantityOfLines, 1];
        }

        using (StreamReader sr = new(fileName))
        {
            var line = sr.ReadLine();
            var splitted = line.Split(',');
            var mathScore = Convert.ToInt32(splitted[3]);
            var scienceScore = Convert.ToInt32(splitted[4]);
            var languageScore = Convert.ToInt32(splitted[5]);
            for (int i = 0; i < newMatrix.GetLength(); i++)
            {
                
            }
        }

        return newMatrix;
    }
    #endregion
}
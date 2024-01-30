// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text;

internal class FileProcessing
{
    const string FILENAME = "phrases.txt";
    const string SEPARATOR = "---------------------------------";
    public static void Main(string[] args)
    {
        var phrases = ProcessText(FILENAME);
        ShowPhrases(phrases);
    }
/// <summary>
/// Recieves a phrase consisting in words splitted by a blank space
/// Shows the quantity of words in the phrase and shows each word in a different line.
/// </summary>
/// <param name="phrase">the phrase to break down</param>
    static void BreakDownPhrase(string phrase)
    {
        var splittedPhrase = phrase.Split(' ');
        Console.WriteLine($"Number of words in the phrase: {splittedPhrase.Length}");
        Console.WriteLine("Break down of the phrase: ");
        foreach (var word in splittedPhrase)
        {
            Console.WriteLine(word);
        }
    }
/// <summary>
/// Contains a list of phrases.
/// It shows:
/// a) the number of the phrase
/// b) the phrase complete
/// c) the breaking down of the phrase and the amount of words in the phrase
/// </summary>
/// <param name="phrases">list of the phrases</param>
    static void ShowPhrases(List<string> phrases)
    {
        for (int i = 0; i < phrases.Count; i++)
        {
            Console.WriteLine($"Phrase number #{i+1}:");
            Console.WriteLine(phrases[i]);
            BreakDownPhrase(phrases[i]);
            Console.WriteLine(SEPARATOR);
        }
    }
/// <summary>
/// Reads the file given by the parameters to create the phrases.
/// Each word will be followed by a blank space unless it's a "."
/// that will be the end of the phrase.
/// </summary>
/// <param name="filename">name of the file</param>
/// <returns></returns>
    static List<string> ProcessText(string filename)
    {
        StringBuilder sb = new();
        var phrases = new List<string>();
        using (StreamReader sr = new(filename))
        {
            string? line = sr.ReadLine();
            while (line != null)
            {
                if (line == ".")
                {
                    phrases.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(line);
                    sb.Append(" ");
                }
                line = sr.ReadLine();
            }
        }
        return phrases;
    }
}
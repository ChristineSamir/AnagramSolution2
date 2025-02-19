namespace Anagrams;

public class Anagram
{
    private readonly Dictionary<string, List<string>> _anagramDictionary = new();

    public Anagram(List<string> dictionary)
    {
        var startTime = DateTime.Now;

        foreach (var word in dictionary)
        {
            // Sort word then add to dictionary
            // Ignore Casing in comparison
          
            var wordCaseInsensitive = word.ToLower().Trim();
            var sortedWord = new string(wordCaseInsensitive.OrderBy(letter => letter).ToArray());

            if (!_anagramDictionary.ContainsKey(sortedWord))
            {
                _anagramDictionary[sortedWord] = new List<string>();
            }

            _anagramDictionary[sortedWord].Add(wordCaseInsensitive);
        }

        var endTime = DateTime.Now;

        var processingTime = endTime - startTime;
        Console.WriteLine($"Performance testing: Processing time is {processingTime}");
    }

    public List<string> GetAnagram(string search)
    {
        var startTime = DateTime.Now;

        var sortedWord = new string(search.ToLower().Trim().OrderBy(letter => letter).ToArray());
        var anagramValues = _anagramDictionary.TryGetValue(sortedWord, out var anagrams)
            ? anagrams
            : new List<string>();

        var endTime = DateTime.Now;
        var retrieveTime = endTime - startTime;
        Console.WriteLine($"Performance testing: Time for getting anagram list is {retrieveTime}");

        return anagramValues;
    }
}
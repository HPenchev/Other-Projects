using System;

class SmallestSubstringContainingTheAlphabet
{
    static void Main()
    {
        Console.WriteLine("Please enter the text:");
        string text = Console.ReadLine();      
        string result = FindSmallestSubstringContainingTheAlphabet(text);
        Console.WriteLine(result);
    }

    //the method returns the smallest string containing the entire English alphabet case-insensitive. In case more than one smallest string
    //occures, the method returns the most left one.
    public static string FindSmallestSubstringContainingTheAlphabet(string text)
    {
        string textToLower = text.ToLower();
        int alphabetLength = 26;
        int textLength = textToLower.Length;       

        for (int i = alphabetLength; i < textLength; i++)
		{
	        for (int j = 0; j + i <= textLength; j++)
			{                
			    string stringToCheck = textToLower.Substring(j, i);
                if (CheckWhetherStringContainsAllLettersFromTheAlphabet(stringToCheck))
                {
                    string result = text.Substring(j, i);
                    return result;
                }
			}
		}

        return null;
    }

    private static bool CheckWhetherStringContainsAllLettersFromTheAlphabet(string text)
    {
        int alphabetStartingASCIINumber = 97;
        int alphabetEndingASCIINumber = 122;

        for (int i = alphabetStartingASCIINumber; i <= alphabetEndingASCIINumber; i++)
        {
            char letterToCheck = (char)i;
            if (text.IndexOf(letterToCheck) == -1)
            {
                return false;
            }
        }

        return true;
    }
}
using System;
using System.Collections.Generic;

namespace MorseCodeConverter
{
    // <summary>
    // A utility class that provides methods to convert text to Morse code.
    // </summary>
    public class MorseCodeConverter
    {
        // <summary>
        // Converts the given text to Morse code.
        //
        // Parameters:
        // - text: The text to be converted to Morse code.
        //
        // Returns:
        // - A string representing the Morse code equivalent of the input text.
        // </summary>
        public static string ConvertToMorseCode(string text)
        {
            // Define the Morse code mappings.
            Dictionary<char, string> morseCodeMappings = new Dictionary<char, string>()
            {
                {'A', ".-"},
                {'B', "-..."},
                {'C', "-.-."},
                {'D', "-.."},
                {'E', "."},
                {'F', "..-."},
                {'G', "--."},
                {'H', "...."},
                {'I', ".."},
                {'J', ".---"},
                {'K', "-.-"},
                {'L', ".-.."},
                {'M', "--"},
                {'N', "-."},
                {'O', "---"},
                {'P', ".--."},
                {'Q', "--.-"},
                {'R', ".-."},
                {'S', "..."},
                {'T', "-"},
                {'U', "..-"},
                {'V', "...-"},
                {'W', ".--"},
                {'X', "-..-"},
                {'Y', "-.--"},
                {'Z', "--.."},
                {'0', "-----"},
                {'1', ".----"},
                {'2', "..---"},
                {'3', "...--"},
                {'4', "....-"},
                {'5', "....."},
                {'6', "-...."},
                {'7', "--..."},
                {'8', "---.."},
                {'9', "----."},
                {' ', " "}
            };

            // Convert the text to uppercase for consistency.
            text = text.ToUpper();

            // Convert each character to its Morse code equivalent.
            List<string> morseCodeList = new List<string>();
            foreach (char c in text)
            {
                if (morseCodeMappings.ContainsKey(c))
                {
                    morseCodeList.Add(morseCodeMappings[c]);
                }
            }

            // Join the Morse code representations of each character with a space.
            string morseCode = string.Join(" ", morseCodeList);

            return morseCode;
        }
    }
}

using System;
using System.Collections.Generic;

namespace sifra
{
    // <summary>
    // Represents a Morse Code encoder and decoder.
    // The class provides methods to encode text into Morse Code and decode Morse Code back into text.
    // </summary>
    public class MorseCodeConverter
    {
        private Dictionary<char, string> morseCodeDictionary;

        // <summary>
        // Constructs a new instance of the MorseCodeConverter class.
        // Initializes the Morse Code dictionary with the standard Morse Code mappings.
        // </summary>
        public MorseCodeConverter()
        {
            morseCodeDictionary = new Dictionary<char, string>()
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
                {' ', "/"}
            };
        }

        // <summary>
        // Encodes the given text into Morse Code.
        //
        // Parameters:
        // - text: The text to be encoded.
        //
        // Returns:
        // - A string representing the encoded Morse Code.
        // </summary>
        public string EncodeToMorseCode(string text)
        {
            text = text.ToUpper();
            string encodedText = "";

            foreach (char c in text)
            {
                if (morseCodeDictionary.ContainsKey(c))
                {
                    encodedText += morseCodeDictionary[c] + " ";
                }
                else
                {
                    encodedText += c;
                }
            }

            return (encodedText.Trim());
        }

        // <summary>
        // Decodes the given Morse Code into text.
        //
        // Parameters:
        // - morseCode: The Morse Code to be decoded.
        //
        // Returns:
        // - A string representing the decoded text.
        // </summary>
        public string DecodeFromMorseCode(string morseCode)
        {
            string[] morseCodeWords = morseCode.Split(new[] { " / " }, StringSplitOptions.None);
            string decodedText = "";

            foreach (string word in morseCodeWords)
            {
                string[] morseCodeLetters = word.Split(' ');

                foreach (string letter in morseCodeLetters)
                {
                    foreach (KeyValuePair<char, string> pair in morseCodeDictionary)
                    {
                        if (pair.Value == letter)
                        {
                            decodedText += pair.Key;
                            break;
                        }
                    }
                }

                decodedText += " ";
            }

            return decodedText.Trim().ToLower();
        }
    }
}
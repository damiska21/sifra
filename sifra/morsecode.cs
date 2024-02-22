using System;
using System.Collections.Generic;

namespace sifra
{
    public class MorseCodeConverter
    {
        private Dictionary<char, string> morseCodeDictionary;

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
                {' ', "/"},
                {'.', ".-.-.-" },
                {',', "--..--" },
                {':', "---..." },
                {'-', "-....-" },
                {'?', "..--.." },
                {'@', ".--.-." }
            };
        }
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
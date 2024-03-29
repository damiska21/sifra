﻿using System;
using System.Collections.Generic;

namespace sifra
{
    public class MorseCodeConverter
    {
        //dictionary na písmenka a jejich morse code verze
        private Dictionary<char, string> morseovka;

        public MorseCodeConverter()
        {
            morseovka = new Dictionary<char, string>()
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
            text = text.ToUpper();//celý text je převeden do velkých písmenek pro konzistenci
            string encodedText = "";

            foreach (char c in text)
            {
                if (morseovka.ContainsKey(c))
                {
                    encodedText += morseovka[c] + " ";
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
            string text = "";

            foreach (string word in morseCodeWords)
            {
                string[] morseCodeLetters = word.Split(' ');

                foreach (string letter in morseCodeLetters)
                {
                    foreach (KeyValuePair<char, string> pair in morseovka)
                    {
                        if (pair.Value == letter)
                        {
                            text += pair.Key;
                            break;
                        }
                    }
                }

                text += " ";
            }

            return text.Trim().ToLower();
        }
    }
}
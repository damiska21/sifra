using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sifra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //zašifrovat
        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(alphabetGen(textBox1.Text));
            //richTextBox1.Text = alphabetGen(textBox1.Text);

            //richTextBox1.Text = morse.EncodeToMorseCode(switchString(alphabetGen(textBox1.Text), richTextBox1.Text));

            //richTextBox1.Text = morseCharsToText(morse.EncodeToMorseCode(richTextBox1.Text), textBox1.Text);
            richTextBox1.Text = morseCharsToText(morse.EncodeToMorseCode(richTextBox1.Text), textBox1.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //richTextBox2.Text = morse.DecodeFromMorseCode(richTextBox2.Text);
            //richTextBox2.Text = switchStringBack(alphabetGen(textBox2.Text), morse.DecodeFromMorseCode(richTextBox2.Text));
            //richTextBox2.Text = morse.DecodeFromMorseCode();
            richTextBox2.Text = morseCharsToTextBack(richTextBox2.Text, textBox2.Text);
        }
        public MorseCodeConverter morse = new MorseCodeConverter();
        
        public string alphabet = "abcdefghijklmnopqrstuvwxyz1234567890";
        public string alphabetGen(string key)
        {
            string retAlphabet = ""; //spřeházená abededa, která se bude vracet
            int keyPos = 0;//pozice, odkud se bere charakter klíče
            int[] keyArray = new int[key.Length];
            //přepíše celý klíč do čísel podle umístění v alphabet
            for (int j = 0; j < key.Length; j++)
            {
                for (int b = 0; b < alphabet.Length; b++)
                {
                    if (alphabet[b] == key[j])
                    {
                        keyArray[j] = b;break;
                    }
                }
            }
            for (int i = 0; i < alphabet.Length; i++)
            {
                int index = i + keyArray[keyPos];
                int posunO = 0;
                posun://posun řeší, kdyby jedno písmeno bylo v abecedě dvakrát, což by bylo nedešifrovatelné
                for (int s = 0; s < retAlphabet.Length; s++)
                {
                    if (alphabet[(index+posunO) % 36] == retAlphabet[s])
                    {
                        posunO++;
                        goto posun;
                    }
                }
                retAlphabet += alphabet[(index+posunO)%36].ToString();
                keyPos++;
                if (keyPos >= key.Length-1)//pokud dojdou charaktery klíče, začíná odznovu
                {
                    keyPos = 0;
                }
            }
            return retAlphabet;
        }
        public string switchString(string modifiedAlphabet, string text)
        {
            string modifiedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    modifiedText += " ";//pokud je v šifře mezera, zůstane tam (zašifruje se až v dalším kroku)
                    continue;
                }
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (alphabet[j] == text[i])
                    {
                        modifiedText+= modifiedAlphabet[j];
                    }
                }
            }
            return modifiedText;
        }
        public string switchStringBack(string modifiedAlphabet, string text)
        {
            string modifiedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    modifiedText += " ";//pokud je v šifře mezera, zůstane tam (zašifruje se až v dalším kroku)
                }
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (modifiedAlphabet[j] == text[i])
                    {
                        modifiedText += alphabet[j];
                    }
                }
            }
            return modifiedText;
        }
        public string morseCharsToText(string text, string key)
        {
            string textOutput = "";
            int alphabetIndex = 0;
            for(int i = 0; i < text.Length; i++)
            {
                alphabetIndex++;
                if (alphabetIndex+2 >= 36)
                {
                    alphabetIndex = 0;
                }
                switch (text[i])
                {
                    case ' ':
                        textOutput += alphabet[alphabetIndex];
                        break;
                    case '.':
                        textOutput+= alphabet[alphabetIndex+1];
                        break;
                    case '-':
                        textOutput+= alphabet[alphabetIndex+2];
                        break;
                }
            }

            return textOutput;
        }
        public string morseCharsToTextBack(string text, string key)
        {
            string textOutput = "";
            int alphabetIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                alphabetIndex++;
                if (alphabetIndex + 2 >= 36)
                {
                    alphabetIndex = 0;
                }
                if (text[i] == alphabet[alphabetIndex])
                {
                    textOutput += ' ';
                }else if (text[i] == alphabet[alphabetIndex+1])
                {
                    textOutput += '.';
                }
                else if (text[i] == alphabet[alphabetIndex+2])
                {
                    textOutput += '-';
                }
            }

            return textOutput;
        }
    }
}

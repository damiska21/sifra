using System;
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
            richTextBox1.Text = morse.EncodeToMorseCode(richTextBox1.Text);
            richTextBox1.Text = morseCharsToText(richTextBox1.Text, textBox1.Text.ToLower());
            richTextBox1.Text = switchString(richTextBox1.Text, alphabetGen(textBox1.Text.ToLower()));
            richTextBox1.Text = alphabetGen(textBox1.Text);
            Clipboard.SetText(richTextBox1.Text); //nastavení schránky
        }
        //dešifrovat
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = switchStringBack(richTextBox2.Text, alphabetGen(textBox2.Text.ToLower()));
            richTextBox2.Text = morseCharsToTextBack(richTextBox2.Text, textBox2.Text.ToLower());
            richTextBox2.Text = morse.DecodeFromMorseCode(richTextBox2.Text);
            Clipboard.SetText(richTextBox2.Text);//nastavení schránky
        }
        //tlačítka na zašifrování jednotlivých kroků
        private void cypher1step(object sender, EventArgs e)
        {
            richTextBox1.Text = morse.EncodeToMorseCode(richTextBox1.Text);
            Clipboard.SetText(richTextBox1.Text);
        }

        private void cypher2step(object sender, EventArgs e)
        {
            richTextBox1.Text = morseCharsToText(richTextBox1.Text, textBox1.Text);
            Clipboard.SetText(richTextBox1.Text);
        }

        private void decypher1step(object sender, EventArgs e)
        {
            richTextBox2.Text = morse.DecodeFromMorseCode(richTextBox2.Text);
            Clipboard.SetText(richTextBox2.Text);
        }

        private void decypher2step(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.Text);
            richTextBox2.Text = morseCharsToTextBack(richTextBox2.Text, textBox2.Text);
        }
        public MorseCodeConverter morse = new MorseCodeConverter();
        //vypsaná celá abeceda se všemi charaktery, ve které s nimi pracuji.
        public string alphabet = "abcdefghijklmnopqrstuvwxyz1234567890.,:-?@";
        public int[] keyArr(string key)
        {
            int[] keyArray = new int[key.Length];
            //přepíše celý klíč do čísel podle umístění v alphabet
            // B v klíči přepíše na 2, E na 5 atd.
            for (int j = 0; j < key.Length; j++)
            {
                for (int b = 0; b < alphabet.Length; b++)
                {
                    if (alphabet[b] == key[j])
                    {
                        keyArray[j] = b; break;
                    }
                }
            }
            return keyArray;
        }
        public string alphabetGen(string key)
        {
            string retAlphabet = ""; //spřeházená abededa, která se bude vracet
            int keyPos = 0;//pozice, odkud se bere charakter klíče
            int[] keyArray = keyArr(key);
            for (int i = 0; i < alphabet.Length; i++)
            {
                int index = i + keyArray[keyPos];
                int posunO = 0;
                posun://posun řeší, kdyby jedno písmeno bylo v abecedě dvakrát, což by bylo nedešifrovatelné
                for (int s = 0; s < retAlphabet.Length; s++)
                {
                    if (alphabet[(index+posunO) % alphabet.Length] == retAlphabet[s])
                    {
                        posunO++;
                        goto posun;
                    }
                }
                retAlphabet += alphabet[(index+posunO)%alphabet.Length].ToString();
                keyPos++;
                if (keyPos >= key.Length-1)//pokud dojdou charaktery klíče, začíná odznovu
                {
                    keyPos = 0;
                }
            }
            return retAlphabet;
        }
        public string switchString(string text, string modifiedAlphabet)
        {
            string modifiedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    modifiedText += " ";//pokud je v šifře mezera, zůstane tam
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
        public string switchStringBack(string text, string modifiedAlphabet)
        {
            string modifiedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    modifiedText += " ";//pokud je v šifře mezera, zůstane tam
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
            int[] keyArray = keyArr(key);
            for(int i = 0; i < text.Length; i++)
            {
                alphabetIndex += keyArray[i%keyArray.Length];
                switch (text[i])
                {
                    case ' ':
                        textOutput += alphabet[alphabetIndex%alphabet.Length];
                        break;
                    case '.':
                        textOutput+= alphabet[(alphabetIndex+1) % alphabet.Length];
                        break;
                    case '-':
                        textOutput+= alphabet[(alphabetIndex+2) % alphabet.Length];
                        break;
                    case '/':
                        textOutput += alphabet[(alphabetIndex + 3) % alphabet.Length];
                        break;
                    default:
                        textOutput += 'x';
                        break;
                }
            }

            return textOutput;
        }
        public string morseCharsToTextBack(string text, string key)
        {
            string textOutput = "";
            int alphabetIndex = 0;
            int[] keyArray = keyArr(key);
            for (int i = 0; i < text.Length; i++)
            {
                alphabetIndex += keyArray[i % keyArray.Length];
                if (alphabetIndex + 3 >= 42)
                {
                    alphabetIndex %= 42;
                }
                if (text[i] == alphabet[alphabetIndex % alphabet.Length])
                {
                    textOutput += ' ';
                }else if (text[i] == alphabet[(alphabetIndex+1)%alphabet.Length])
                {
                    textOutput += '.';
                }
                else if (text[i] == alphabet[(alphabetIndex+2) % alphabet.Length])
                {
                    textOutput += '-';
                }
                else if (text[i] == alphabet[(alphabetIndex+3) % alphabet.Length])
                {
                    textOutput += '/';
                }
            }

            return textOutput;
        }
    }
}

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
            MessageBox.Show(alphabetGen(textBox1.Text));
            richTextBox1.Text = alphabetGen(textBox1.Text);
        }
        public string alphabet = "abcdefghijklmnopqrstuvwxyz1234567890";
        public string alphabetGen(string key)
        {
            string retAlphabet = "";
            int keyPos = 0;
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
                retAlphabet += alphabet[index%36].ToString();
                keyPos++;
                if (keyPos >= key.Length-1)
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
                    modifiedText += " ";
                }
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (alphabet[j] == text[i])
                    {
                        modifiedText+= alphabet[j];
                    }
                }
            }
            return modifiedText;
        }
    }
}

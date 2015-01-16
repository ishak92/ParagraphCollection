using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParagraphProject;

namespace WindowProjectForParagraph
{
    public partial class Form1 : Form
    {
        private ParagraphCollection currentParagraphCollection;
        public Form1()
        {
            currentParagraphCollection = new ParagraphCollection();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var searchItems = this.textBox1.Text.Split();
            var itog = currentParagraphCollection;
            foreach (var word in searchItems)
            {
                itog = itog.getParagraphsWithSubWord(word);
            }
            foreach (var par in itog.GetAllParagraphs())
            {
                this.richTextBox1.Text += par.getText();
                this.richTextBox1.Text += "----------------------------------\n\r";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentParagraphCollection = new ParagraphCollection();

            this.folderBrowserDialog1.ShowDialog();
            MessageBox.Show(this.folderBrowserDialog1.SelectedPath);
            var files = Directory.GetFiles(this.folderBrowserDialog1.SelectedPath);
            var parExtractor = new WordParagraphExtracter();
            foreach (var file in files)
            {
                parExtractor.AddParagraphsFromFile(file);
            }
            currentParagraphCollection = parExtractor.getAllParagraphs();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show( currentParagraphCollection.getNumberOfParagpaphs().ToString() );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
        }
    }
}

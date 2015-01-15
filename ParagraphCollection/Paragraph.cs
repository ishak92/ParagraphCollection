using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ParagraphCollection
{
    public class Paragraph
    {
        private List<string> WordsCollection;
        private string Text;

        public Paragraph(string text)
        {
            Text = text;
            text = text.ToLower();
            text = text.Replace(",", "").Replace(".", "");
            var words = text.Split(' ');
            
            WordsCollection = new List<string>(words);

        }

        string getText()
        {
            return Text;
        }

        public bool IsContainSubWord(string subWord)
        {
            return WordsCollection.Any(word => word.Contains(subWord));
        }

        void AddWord(string word)
        {
            if(!WordsCollection.Contains(word))
                WordsCollection.Add(word);
        }
    }
}

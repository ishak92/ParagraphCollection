using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace ParagraphProject
{
    public class WordParagraphExtracter
    {
        private Microsoft.Office.Interop.Word.Application gWord;
        private ParagraphCollection parCollection;

        public WordParagraphExtracter()
        {
            gWord = new Microsoft.Office.Interop.Word.Application();
            parCollection = new ParagraphCollection();

        }

        public void AddParagraphsFromFile(object filePath)
        {
            
            object miss = System.Reflection.Missing.Value;
            object readOnly = true;
            var doc = gWord.Documents.Open(ref filePath, ref miss, ref readOnly, ref miss,
                ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss);
            addAllParagraphs(doc);
            doc.Close();
        }

        public void addAllParagraphs(Document doc)
        {
            for (int i = 0; i < doc.Paragraphs.Count; i++)
            {
                var par = new Paragraph(doc.Paragraphs[i + 1].Range.Text.ToString());
                parCollection.AddParagraph(par);
            }

        }

        public ParagraphCollection getAllParagraphs()
        {
            return parCollection;
        }

        public void KillWord()
        {
            gWord.Quit();
        }
    }
}

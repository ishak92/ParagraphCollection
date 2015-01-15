using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace ParagraphCollection
{
    class WordParagraphExtracter
    {
        private Microsoft.Office.Interop.Word.Application gWord;
        private Microsoft.Office.Interop.Word.Document gDocs;

        public WordParagraphExtracter(object filePath)
        {
            gWord = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object readOnly = true;
            gDocs = gWord.Documents.Open(ref filePath, ref miss, ref readOnly, ref miss,
                ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss);
        }

        public ParagraphCollection getAllParagraphs()
        {
            var parCollection = new ParagraphCollection();
            for (int i = 0; i < gDocs.Paragraphs.Count; i++)
            {
                var par = new Paragraph(gDocs.Paragraphs[i + 1].Range.Text.ToString());
                parCollection.AddParagraph(par);
            }

            gDocs.Close();
            gWord.Quit();
            return parCollection;
        }
    }
}

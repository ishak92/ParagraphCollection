using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParagraphProject
{
    public class ParagraphCollection
    {
        private List<Paragraph> ParagraphList;

        public ParagraphCollection()
        {
            ParagraphList = new List<Paragraph>();
        }

        void addParagraph(Paragraph par)
        {
            ParagraphList.Add(par);
        }

        public List<Paragraph> GetAllParagraphs()
        {
            return ParagraphList;
        }

        public ParagraphCollection getParagraphsWithSubWord(string subWord)
        {
            var parCol = new ParagraphCollection();

            foreach (var par in ParagraphList.Where(par => par.IsContainSubWord(subWord)))
            {
                parCol.addParagraph(par);
            }

            return parCol;
        }

        public int getNumberOfParagpaphs()
        {
            return ParagraphList.Count;
        }

        public void AddParagraph(Paragraph par)
        {
            ParagraphList.Add(par);
        }
    }
}

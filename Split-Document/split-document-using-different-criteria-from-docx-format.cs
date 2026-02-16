using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Load the source DOCX document.
        Document doc = new Document("Input.docx");

        // Base name for the output HTML files.
        string outputFileName = "SplitOutput.html";

        // Create HTML save options and specify the split criteria.
        // In this example we split at section breaks and at heading paragraphs.
        HtmlSaveOptions saveOptions = new HtmlSaveOptions();
        saveOptions.DocumentSplitCriteria = DocumentSplitCriteria.SectionBreak | DocumentSplitCriteria.HeadingParagraph;

        // Assign a callback to control the naming of each split part.
        saveOptions.DocumentPartSavingCallback = new CustomPartNaming(outputFileName, saveOptions.DocumentSplitCriteria);

        // Save the document; Aspose.Words will generate separate HTML files according to the criteria.
        doc.Save(outputFileName, saveOptions);
    }

    // Callback that customizes the file name (and optionally the stream) for each document part.
    private class CustomPartNaming : IDocumentPartSavingCallback
    {
        private readonly string _baseFileName;
        private readonly DocumentSplitCriteria _criteria;
        private int _partIndex;

        public CustomPartNaming(string baseFileName, DocumentSplitCriteria criteria)
        {
            _baseFileName = baseFileName;
            _criteria = criteria;
        }

        void IDocumentPartSavingCallback.DocumentPartSaving(DocumentPartSavingArgs args)
        {
            // Determine a readable part type based on the split criteria used.
            string partType = _criteria switch
            {
                DocumentSplitCriteria.PageBreak => "Page",
                DocumentSplitCriteria.ColumnBreak => "Column",
                DocumentSplitCriteria.SectionBreak => "Section",
                DocumentSplitCriteria.HeadingParagraph => "Heading",
                _ => "Part"
            };

            // Build a new file name: <base>_partN_<type>.html
            string newFileName = $"{Path.GetFileNameWithoutExtension(_baseFileName)}_part{++_partIndex}_{partType}{Path.GetExtension(args.DocumentPartFileName)}";

            // Set the file name for this part.
            args.DocumentPartFileName = newFileName;

            // Optionally provide a custom stream for the part (demonstrates both approaches).
            string fullPath = Path.Combine(Path.GetDirectoryName(_baseFileName) ?? "", newFileName);
            args.DocumentPartStream = new FileStream(fullPath, FileMode.Create);
        }
    }
}

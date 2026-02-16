using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;

class DocumentSplitter
{
    static void Main()
    {
        // Load the source DOCX document.
        Document doc = new Document("InputDocument.docx");

        // Configure HTML save options to split the document at each section break.
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            DocumentSplitCriteria = DocumentSplitCriteria.SectionBreak,
            DocumentPartSavingCallback = new PartRenamer("SplitDocument")
        };

        // Save the document; Aspose.Words will create separate HTML files for each part.
        doc.Save("SplitDocument.html", saveOptions);
    }

    // Callback that renames each split part file.
    private class PartRenamer : IDocumentPartSavingCallback
    {
        private readonly string _baseName;
        private int _partIndex = 0;

        public PartRenamer(string baseName)
        {
            _baseName = baseName;
        }

        void IDocumentPartSavingCallback.DocumentPartSaving(DocumentPartSavingArgs args)
        {
            // Generate a new filename for each part.
            string extension = Path.GetExtension(args.DocumentPartFileName);
            string newFileName = $"{_baseName}_Part{++_partIndex}{extension}";
            args.DocumentPartFileName = newFileName;
        }
    }
}

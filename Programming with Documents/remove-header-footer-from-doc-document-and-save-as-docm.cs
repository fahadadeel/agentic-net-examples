using System;
using Aspose.Words;
using Aspose.Words.Saving;

class RemoveHeadersFootersAndSaveAsDocm
{
    static void Main()
    {
        // Path to the source DOC file.
        string inputPath = @"C:\Docs\SourceDocument.doc";

        // Path where the resulting DOCM file will be saved.
        string outputPath = @"C:\Docs\ResultDocument.docm";

        // Load the existing document.
        Document doc = new Document(inputPath);

        // Remove all headers and footers from each section.
        foreach (Section section in doc.Sections)
        {
            // Clear the HeadersFooters collection for the current section.
            section.HeadersFooters.Clear();
        }

        // Prepare save options to specify the DOCM format.
        OoxmlSaveOptions saveOptions = new OoxmlSaveOptions(SaveFormat.Docm);

        // Save the modified document as DOCM.
        doc.Save(outputPath, saveOptions);
    }
}

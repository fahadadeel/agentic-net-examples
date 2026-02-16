using System;
using Aspose.Words;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Load the source DOC document.
        Document doc = new Document("Input.doc");

        // Remove all headers and footers from every section.
        foreach (Section section in doc.Sections)
        {
            section.HeadersFooters.Clear();
        }

        // Configure save options for the DOC format.
        DocSaveOptions saveOptions = new DocSaveOptions(SaveFormat.Doc);

        // Save the document without headers/footers.
        doc.Save("Output.doc", saveOptions);
    }
}

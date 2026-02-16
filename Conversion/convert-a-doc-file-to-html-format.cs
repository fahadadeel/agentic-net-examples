using System;
using Aspose.Words;
using Aspose.Words.Loading; // Added namespace for LoadOptions
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Path to the source DOC file.
        string inputPath = "input.doc";

        // Path where the HTML output will be saved.
        string outputPath = "output.html";

        // Load the DOC file. Explicitly specify the load format to ensure correct detection.
        Document doc = new Document(inputPath, new LoadOptions { LoadFormat = LoadFormat.Doc });

        // Configure HTML save options (optional but demonstrates usage of HtmlSaveOptions).
        HtmlSaveOptions saveOptions = new HtmlSaveOptions
        {
            // Save using HTML5 standard.
            HtmlVersion = HtmlVersion.Html5,
            // Produce nicely indented HTML for readability.
            PrettyFormat = true
        };

        // Save the document as HTML.
        doc.Save(outputPath, saveOptions);
    }
}

using System;
using Aspose.Words;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // Add some content to the document.
        DocumentBuilder builder = new DocumentBuilder(doc);
        builder.Writeln("Hello world!");

        // Configure layout options for the document.
        // Document.LayoutOptions is read‑only, so we modify the existing instance instead of assigning a new one.
        doc.LayoutOptions.ShowHiddenText = true;
        doc.LayoutOptions.ShowParagraphMarks = true;

        // Set PDF save options, e.g., page layout and zoom behavior.
        PdfSaveOptions pdfOptions = new PdfSaveOptions
        {
            PageLayout = PdfPageLayout.TwoPageLeft,   // Display two pages at a time, odd pages on the left.
            ZoomBehavior = PdfZoomBehavior.FitPage    // Fit the whole page in the viewer.
        };

        // Save the document as a PDF using the specified options.
        doc.Save("Output.pdf", pdfOptions);
    }
}

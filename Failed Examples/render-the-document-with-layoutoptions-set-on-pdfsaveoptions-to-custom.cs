// ALL ATTEMPTS FAILED. Below is the last generated code.

using System;
using Aspose.Words;
using Aspose.Words.Layout;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Load the source document.
        Document doc = new Document("Input.docx");

        // -------------------------------------------------
        // Customize the page layout of the first section.
        // -------------------------------------------------
        PageSetup setup = doc.Sections[0].PageSetup;

        // Page size (A4 in points).
        setup.PageWidth = 595;   // 8.27 inches * 72
        setup.PageHeight = 842;  // 11.69 inches * 72

        // Orientation.
        setup.Orientation = Orientation.Portrait;

        // Margins (1 inch on each side).
        setup.LeftMargin = 72;
        setup.RightMargin = 72;
        setup.TopMargin = 72;
        setup.BottomMargin = 72;

        // Columns (2 columns).
        setup.TextColumns.SetCount(2);

        // Line spacing (14 points).
        setup.LineSpacing = 14;

        // Paragraph spacing (12 points before and after).
        setup.SpaceBefore = 12;
        setup.SpaceAfter = 12;

        // -------------------------------------------------
        // Create PdfSaveOptions and attach LayoutOptions.
        // -------------------------------------------------
        PdfSaveOptions pdfOptions = new PdfSaveOptions();

        // LayoutOptions allow further control over the layout process.
        LayoutOptions layout = new LayoutOptions
        {
            // Ensure the custom page setup is respected (do not use printer metrics).
            IgnorePrinterMetrics = false
        };

        // Assign the LayoutOptions to the save options.
        pdfOptions.LayoutOptions = layout;

        // -------------------------------------------------
        // Save the document as PDF with the specified options.
        // -------------------------------------------------
        doc.Save("Output.pdf", pdfOptions);
    }
}

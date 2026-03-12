using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPdf = "input.pdf";
        const string outputPdf = "stamped_output.pdf";
        const string svgStamp = "stamp.svg";

        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdf}");
            return;
        }

        if (!File.Exists(svgStamp))
        {
            Console.Error.WriteLine($"SVG stamp not found: {svgStamp}");
            return;
        }

        // Initialize the facade and bind the source PDF
        PdfFileStamp fileStamp = new PdfFileStamp();
        fileStamp.BindPdf(inputPdf);

        // Create a stamp and bind the SVG image (vector‑based)
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
        stamp.BindImage(svgStamp);               // SVG is treated as a vector image
        stamp.SetOrigin(100, 500);               // Position on the page (X, Y)
        stamp.SetImageSize(200, 200);            // Desired size (width, height)
        stamp.IsBackground = false;              // Place on top of page content
        stamp.Opacity = 0.9f;                    // Slight transparency

        // Apply the stamp to all pages (Pages = null means all pages)
        fileStamp.AddStamp(stamp);

        // Save the stamped PDF and release resources
        fileStamp.Save(outputPdf);
        fileStamp.Close();

        Console.WriteLine($"Stamped PDF saved to '{outputPdf}'.");
    }
}
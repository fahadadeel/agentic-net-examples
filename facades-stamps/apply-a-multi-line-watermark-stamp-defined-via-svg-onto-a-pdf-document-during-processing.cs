using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPdf  = "input.pdf";
        const string outputPdf = "watermarked.pdf";
        const string svgStamp  = "watermark.svg";

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

        // Initialize the PdfFileStamp facade (parameterless constructor – avoids obsolete InputFile/OutputFile)
        PdfFileStamp fileStamp = new PdfFileStamp();

        // Bind the source PDF document
        fileStamp.BindPdf(inputPdf);

        // Create a stamp object and bind the SVG image (Aspose.Pdf.Facades.Stamp supports image formats, including SVG)
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
        stamp.BindImage(svgStamp);

        // Position the stamp (origin is measured from the bottom‑left corner)
        stamp.SetOrigin(100, 400);          // X = 100, Y = 400
        // Define the size of the rendered SVG
        stamp.SetImageSize(200, 100);       // width = 200, height = 100

        // Make the stamp appear as a background watermark and set its opacity
        stamp.IsBackground = true;
        stamp.Opacity = 0.5f;               // 50 % opacity for a translucent effect

        // Add the configured stamp to the PDF (applies to all pages)
        fileStamp.AddStamp(stamp);

        // Save the resulting PDF
        fileStamp.Save(outputPdf);

        // Close the facade to release resources
        fileStamp.Close();
    }
}
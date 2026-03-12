using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPclPath = "input.pcl";
        const string outputPdfPath = "output.pdf";

        if (!File.Exists(inputPclPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPclPath}");
            return;
        }

        // Load the PCL file and convert it to a PDF document
        using (Aspose.Pdf.Document pdfDoc = new Aspose.Pdf.Document(inputPclPath, new Aspose.Pdf.PclLoadOptions()))
        {
            // Initialize the PdfFileStamp facade with the PDF document
            Aspose.Pdf.Facades.PdfFileStamp fileStamp = new Aspose.Pdf.Facades.PdfFileStamp(pdfDoc);
            fileStamp.OutputFile = outputPdfPath; // specify output file

            // Create multi‑line formatted text for the watermark
            string watermarkText = "CONFIDENTIAL\nDo Not Distribute";
            Aspose.Pdf.Facades.FormattedText formattedText = new Aspose.Pdf.Facades.FormattedText(
                watermarkText,                     // text (supports line breaks)
                System.Drawing.Color.Red,          // text color (System.Drawing.Color is required)
                "Helvetica",                       // font name
                Aspose.Pdf.Facades.EncodingType.Winansi,
                false,                             // embed font flag
                48);                               // font size

            // Create a stamp and bind the formatted text to it
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(formattedText);
            stamp.IsBackground = true;   // place the watermark behind page content
            stamp.Opacity = 0.3f;        // semi‑transparent
            stamp.SetOrigin(100, 400);   // position (adjust as needed)

            // Add the stamp to all pages of the document
            fileStamp.AddStamp(stamp);

            // Save the watermarked PDF
            fileStamp.Close(); // Close triggers the save operation
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdfPath}'.");
    }
}
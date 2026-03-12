using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text;

class Program
{
    static void Main()
    {
        const string inputPdf = "input.pdf";   // source PDF
        const string outputPdf = "output.pdf"; // result PDF

        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input file not found: {inputPdf}");
            return;
        }

        // Initialize the facade for stamping
        PdfFileStamp fileStamp = new PdfFileStamp();

        // Load the source PDF
        fileStamp.BindPdf(inputPdf);

        // Create a stamp instance (fully qualified to avoid ambiguity)
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

        // Use a text stamp (FormattedText) as the stamp content
        FormattedText ft = new FormattedText(
            "CONFIDENTIAL",                     // text
            System.Drawing.Color.Red,           // text color (System.Drawing required)
            "Helvetica",                       // font name
            EncodingType.Winansi,               // encoding
            false,                              // embed font flag
            48);                                // font size

        // Bind the formatted text to the stamp
        stamp.BindLogo(ft);

        // Set the desired rotation angle (degrees)
        stamp.Rotation = 45f; // any float value representing degrees

        // Add the stamp to the document (applies to all pages by default)
        fileStamp.AddStamp(stamp);

        // Save the modified PDF
        fileStamp.Save(outputPdf);

        // Release resources
        fileStamp.Close();
    }
}
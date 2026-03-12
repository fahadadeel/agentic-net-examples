using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

public class WatermarkExample
{
    /// <summary>
    /// Applies a multi‑line text watermark to a PDF loaded from a memory buffer.
    /// </summary>
    /// <param name="pdfBytes">PDF content as a byte array.</param>
    /// <param name="outputPath">File path where the watermarked PDF will be saved.</param>
    public static void ApplyWatermark(byte[] pdfBytes, string outputPath)
    {
        // Load the PDF from the in‑memory byte array.
        using (MemoryStream ms = new MemoryStream(pdfBytes))
        using (Document doc = new Document(ms))
        {
            // Initialize the PdfFileStamp facade with the loaded document.
            Aspose.Pdf.Facades.PdfFileStamp fileStamp = new Aspose.Pdf.Facades.PdfFileStamp(doc);

            // Create multi‑line formatted text for the watermark.
            Aspose.Pdf.Facades.FormattedText formattedText = new Aspose.Pdf.Facades.FormattedText(
                "Confidential\nDo Not Distribute\nCompany XYZ",   // text (lines separated by \n)
                System.Drawing.Color.Gray,                       // text color (fully qualified)
                "Helvetica",                                     // font name
                Aspose.Pdf.Facades.EncodingType.Winansi,          // encoding (fully qualified)
                false,                                            // embed font flag
                48);                                               // font size

            // Create a stamp, configure its appearance, and bind the formatted text.
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.IsBackground = true;   // place the watermark behind page content
            stamp.Opacity = 0.5f;        // semi‑transparent
            stamp.BindLogo(formattedText); // attach the text to the stamp
            // Optional: set the origin of the stamp on the page.
            stamp.SetOrigin(100, 400);

            // Add the stamp to the document (applies to all pages).
            fileStamp.AddStamp(stamp);

            // Save the watermarked PDF to the specified output file.
            fileStamp.Save(outputPath);
            fileStamp.Close(); // close the facade to release resources
        }
    }

    // Entry point required for compilation.
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: WatermarkExample <inputPdfPath> <outputPdfPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        byte[] pdfBytes = File.ReadAllBytes(inputPath);
        ApplyWatermark(pdfBytes, outputPath);
        Console.WriteLine($"Watermarked PDF saved to {outputPath}");
    }
}
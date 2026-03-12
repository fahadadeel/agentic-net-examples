using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string mhtPath = "input.mht";
        const string outputPath = "watermarked.pdf";

        if (!File.Exists(mhtPath))
        {
            Console.Error.WriteLine($"File not found: {mhtPath}");
            return;
        }

        // Load the MHT file into a PDF document using the correct load options
        using (Document doc = new Document(mhtPath, new MhtLoadOptions()))
        {
            // Create a multi‑line formatted text for the watermark
            FormattedText ft = new FormattedText(
                "Confidential\nDo Not Distribute\nCompany XYZ", // text with line breaks
                System.Drawing.Color.Red,                      // text color
                "Helvetica",                                   // font name
                EncodingType.Winansi,                          // encoding
                false,                                         // embed font flag
                48);                                           // font size

            // Configure the stamp with the formatted text
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(ft);          // attach the formatted text to the stamp
            stamp.SetOrigin(100, 400);   // position of the stamp (x, y) in points
            stamp.Opacity = 0.5f;        // semi‑transparent
            stamp.IsBackground = true;   // place the stamp behind page content

            // Apply the stamp to the entire document using PdfFileStamp
            using (PdfFileStamp fileStamp = new PdfFileStamp(doc))
            {
                fileStamp.AddStamp(stamp);
                fileStamp.Save(outputPath); // save the result
                fileStamp.Close();          // finalize the operation
            }
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPath}'.");
    }
}

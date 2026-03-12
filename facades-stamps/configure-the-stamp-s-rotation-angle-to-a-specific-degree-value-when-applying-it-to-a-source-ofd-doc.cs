using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text;

class Program
{
    static void Main()
    {
        const string inputOfdPath = "input.ofd";
        const string outputPdfPath = "output.pdf";
        const float rotationAngle = 45f; // desired rotation in degrees

        if (!File.Exists(inputOfdPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputOfdPath}");
            return;
        }

        // Load the OFD file (input format) as a PDF document
        using (Document doc = new Document(inputOfdPath, new OfdLoadOptions()))
        {
            // Initialize PdfFileStamp with the loaded document
            using (PdfFileStamp fileStamp = new PdfFileStamp(doc))
            {
                // Create a simple text stamp – fully qualified to avoid ambiguity
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

                // Prepare formatted text for the stamp (FormattedText expects System.Drawing.Color)
                FormattedText ft = new FormattedText(
                    "CONFIDENTIAL",                     // text
                    System.Drawing.Color.Red,           // text color
                    "Helvetica",                        // font name
                    EncodingType.Winansi,               // encoding
                    false,                              // embed font
                    36);                                // font size

                // Bind the formatted text to the stamp
                stamp.BindLogo(ft);

                // Set the rotation angle (arbitrary degrees)
                stamp.Rotation = rotationAngle;

                // Add the stamp to the document
                fileStamp.AddStamp(stamp);

                // Save the stamped document to the desired output path
                fileStamp.Save(outputPdfPath);
            }
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdfPath}'.");
    }
}

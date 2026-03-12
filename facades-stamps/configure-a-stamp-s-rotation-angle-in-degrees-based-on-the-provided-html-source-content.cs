using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Pdf.Facades;          // Facade API for stamping
using Aspose.Pdf;                  // Core API (for FormattedText, etc.)

class Program
{
    static void Main()
    {
        // Paths for the source PDF, the HTML file containing rotation info, and the output PDF
        const string inputPdfPath   = "input.pdf";
        const string htmlSourcePath = "rotationInfo.html";
        const string outputPdfPath  = "output.pdf";

        // Ensure the required files exist
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }
        if (!File.Exists(htmlSourcePath))
        {
            Console.Error.WriteLine($"HTML source not found: {htmlSourcePath}");
            return;
        }

        // -----------------------------------------------------------------
        // Extract rotation angle (in degrees) from the HTML source.
        // Expected format in the HTML:  rotate: <number>;
        // Example: <style>.stamp { rotate: 45; }</style>
        // -----------------------------------------------------------------
        string htmlContent = File.ReadAllText(htmlSourcePath);
        float rotationAngle = 0f; // Default rotation

        Match match = Regex.Match(htmlContent, @"rotate\s*:\s*(\d+)", RegexOptions.IgnoreCase);
        if (match.Success && float.TryParse(match.Groups[1].Value, out float parsedAngle))
        {
            rotationAngle = parsedAngle;
        }
        else
        {
            Console.WriteLine("No rotation angle found in HTML; using default 0°.");
        }

        // -----------------------------------------------------------------
        // Create a PdfFileStamp facade, bind the source PDF, configure the stamp,
        // and apply it to all pages.
        // -----------------------------------------------------------------
        using (PdfFileStamp fileStamp = new PdfFileStamp(inputPdfPath, outputPdfPath))
        {
            // Create a text stamp using FormattedText (requires System.Drawing.Color)
            // Note: System.Drawing is Windows‑only; the color is used only for the stamp appearance.
            FormattedText ft = new FormattedText(
                "Stamped Text",
                System.Drawing.Color.Red,          // Text color
                "Helvetica",                       // Font name
                EncodingType.Winansi,              // Encoding
                false,                             // IsEmbedded
                36);                               // Font size

            // Fully qualified Stamp to avoid ambiguity with Aspose.Pdf.Stamp
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(ft);                     // Use the formatted text as stamp content
            stamp.IsBackground = false;             // Place stamp on top of page content
            stamp.Rotation = rotationAngle;         // Set rotation in degrees (multiple of 90 works with Rotate,
                                                    // arbitrary angles also accepted via Rotation property)

            // Optionally set position; here we place it near the center of the page.
            // SetOrigin expects coordinates measured from the lower‑left corner.
            stamp.SetOrigin(200, 400);

            // Apply the stamp to all pages of the document
            fileStamp.AddStamp(stamp);

            // Close the facade to finalize the output file
            fileStamp.Close();
        }

        Console.WriteLine($"Stamp applied with rotation {rotationAngle}° and saved to '{outputPdfPath}'.");
    }
}
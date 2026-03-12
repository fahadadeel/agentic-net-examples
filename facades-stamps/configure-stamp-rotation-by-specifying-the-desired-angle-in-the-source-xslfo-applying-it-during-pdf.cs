using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string xslFoPath   = "input.fo";      // XSL‑FO source
        const string stampImgPath = "stamp.png";    // Image to be used as stamp
        const string outputPdf   = "output.pdf";

        if (!File.Exists(xslFoPath))
        {
            Console.Error.WriteLine($"XSL‑FO file not found: {xslFoPath}");
            return;
        }

        if (!File.Exists(stampImgPath))
        {
            Console.Error.WriteLine($"Stamp image not found: {stampImgPath}");
            return;
        }

        // -----------------------------------------------------------------
        // Load the XSL‑FO document.  XslFoLoadOptions is the concrete
        // LoadOptions class for XSL‑FO input.
        // -----------------------------------------------------------------
        using (Document doc = new Document(xslFoPath, new XslFoLoadOptions()))
        {
            // -----------------------------------------------------------------
            // Extract the desired rotation angle from the XSL‑FO file.
            // The example assumes an attribute named "rotation" on the root
            // element, e.g. <fo:root rotation="45">.
            // -----------------------------------------------------------------
            float rotationAngle = 0f; // default: no rotation
            try
            {
                XDocument xDoc = XDocument.Load(xslFoPath);
                XAttribute rotAttr = xDoc.Root?.Attribute("rotation");
                if (rotAttr != null && float.TryParse(rotAttr.Value, out float parsed))
                {
                    rotationAngle = parsed;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to read rotation angle: {ex.Message}");
            }

            // -----------------------------------------------------------------
            // Apply the stamp using the Facades API (PdfFileStamp).
            // PdfFileStamp can be constructed directly from a Document instance.
            // -----------------------------------------------------------------
            using (PdfFileStamp fileStamp = new PdfFileStamp(doc))
            {
                // Create a stamp object.
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

                // Bind an image to the stamp.
                stamp.BindImage(stampImgPath);

                // Set the rotation angle (in degrees) obtained from the XSL‑FO.
                stamp.Rotation = rotationAngle;

                // Optional: position the stamp on the page.
                stamp.SetOrigin(100f, 100f); // lower‑left corner at (100,100)

                // Add the stamp to all pages of the document.
                fileStamp.AddStamp(stamp);

                // Close the facade to finalize stamping.
                fileStamp.Close();
            }

            // -----------------------------------------------------------------
            // Save the final PDF.
            // -----------------------------------------------------------------
            doc.Save(outputPdf);
            Console.WriteLine($"PDF generated with stamp rotation {rotationAngle}°: {outputPdf}");
        }
    }
}
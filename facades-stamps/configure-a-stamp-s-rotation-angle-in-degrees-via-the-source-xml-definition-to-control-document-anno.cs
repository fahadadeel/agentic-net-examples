using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPdf  = "input.pdf";          // source PDF to be stamped
        const string outputPdf = "output.pdf";         // result PDF
        const string configXml = "stampConfig.xml";    // XML defining the rotation angle

        // Validate file existence
        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdf}");
            return;
        }
        if (!File.Exists(configXml))
        {
            Console.Error.WriteLine($"Config XML not found: {configXml}");
            return;
        }

        // -----------------------------------------------------------------
        // Load rotation angle from XML.
        // Expected format:
        // <Stamp>
        //     <Rotation>45</Rotation>
        // </Stamp>
        // -----------------------------------------------------------------
        float rotationAngle = 0f;
        try
        {
            XDocument xmlDoc = XDocument.Load(configXml);
            XElement rotationElem = xmlDoc.Root.Element("Rotation");
            if (rotationElem != null && float.TryParse(rotationElem.Value, out float parsed))
                rotationAngle = parsed;
            else
                Console.WriteLine("Rotation element missing or invalid; defaulting to 0.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to read XML configuration: {ex.Message}");
            return;
        }

        // -----------------------------------------------------------------
        // Apply the rotation to a stamp using the Facades API.
        // PdfFileStamp implements IDisposable, so we wrap it in a using block
        // (document-disposal-with-using rule).
        // -----------------------------------------------------------------
        using (PdfFileStamp fileStamp = new PdfFileStamp())
        {
            // Bind the source PDF that will receive the stamp.
            fileStamp.BindPdf(inputPdf);

            // Create a Facades Stamp and bind a page from the same PDF as its content.
            // This is the correct way to use a PDF page as a stamp with PdfFileStamp.
            Stamp stamp = new Stamp();
            stamp.BindPdf(inputPdf, 1); // use first page as stamp content

            // Set the rotation angle (degrees). Stamp.Rotation is available in the Facades API.
            stamp.Rotation = rotationAngle;

            // Optionally set the stamp position. Here we place it at the lower‑left corner.
            // Adjust as needed or expose via XML as well.
            stamp.SetOrigin(0, 0);

            // Add the configured stamp to the document.
            fileStamp.AddStamp(stamp);

            // Save the stamped PDF.
            fileStamp.Save(outputPdf);
            // fileStamp.Close() is optional because the using block disposes the object.
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdf}' with rotation {rotationAngle} degrees.");
    }
}

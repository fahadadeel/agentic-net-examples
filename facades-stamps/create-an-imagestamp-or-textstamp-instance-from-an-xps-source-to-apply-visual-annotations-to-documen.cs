using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths for the target PDF, the XPS source, and the output PDF
        const string targetPdfPath = "target.pdf";
        const string xpsPath = "stamp.xps";
        const string outputPdfPath = "annotated.pdf";

        // ------------------------------------------------------------
        // Ensure the source PDF exists – create a simple one if missing
        // ------------------------------------------------------------
        if (!File.Exists(targetPdfPath))
        {
            using (var placeholder = new Document())
            {
                // Add a single blank page
                placeholder.Pages.Add();
                placeholder.Save(targetPdfPath);
            }
        }

        // ------------------------------------------------------------
        // Ensure the XPS file exists – otherwise the program cannot run
        // ------------------------------------------------------------
        if (!File.Exists(xpsPath))
        {
            Console.WriteLine($"XPS source file '{xpsPath}' not found. Please provide a valid XPS file.");
            return;
        }

        // Load the target PDF document
        using (Document targetDoc = new Document(targetPdfPath))
        {
            // Convert the XPS file to PDF and keep it in a memory stream
            using (MemoryStream xpsPdfStream = new MemoryStream())
            {
                // Load XPS using the required XpsLoadOptions
                using (Document xpsDoc = new Document(xpsPath, new XpsLoadOptions()))
                {
                    // Save the XPS content as PDF into the memory stream
                    xpsDoc.Save(xpsPdfStream);
                }

                // Reset stream position before reading
                xpsPdfStream.Position = 0;

                // Initialize the PdfFileStamp facade
                using (PdfFileStamp fileStamp = new PdfFileStamp())
                {
                    // Bind the target PDF file to the facade
                    fileStamp.BindPdf(targetPdfPath);

                    // Create a Stamp object that will be used as the visual annotation
                    Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

                    // Bind the PDF generated from the XPS as the stamp source (first page)
                    stamp.BindPdf(xpsPdfStream, 1);

                    // Optional visual settings for the stamp
                    stamp.IsBackground = true;   // place stamp behind page content
                    stamp.Opacity = 0.5f;        // semi‑transparent

                    // Add the stamp to all pages of the target document
                    fileStamp.AddStamp(stamp);

                    // Save the annotated PDF
                    fileStamp.Save(outputPdfPath);
                }
            }
        }

        Console.WriteLine($"Annotated PDF saved to '{outputPdfPath}'.");
    }
}

using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths – adjust as needed
        const string mhtPath      = "source.mht";      // MHT file to load
        const string targetPdf    = "target.pdf";      // PDF that will receive the stamp
        const string outputPdf    = "stamped_output.pdf";

        // Verify input files exist
        if (!File.Exists(mhtPath))
        {
            Console.Error.WriteLine($"MHT source not found: {mhtPath}");
            return;
        }
        if (!File.Exists(targetPdf))
        {
            Console.Error.WriteLine($"Target PDF not found: {targetPdf}");
            return;
        }

        // 1. Load the MHT file into a PDF document using MhtLoadOptions
        MhtLoadOptions mhtLoadOptions = new MhtLoadOptions();
        using (Document mhtDoc = new Document(mhtPath, mhtLoadOptions))
        {
            // 2. Extract plain text from the loaded document
            TextAbsorber absorber = new TextAbsorber();
            mhtDoc.Pages.Accept(absorber);
            string extractedText = absorber.Text?.Trim() ?? string.Empty;

            // 3. Create a TextStamp using the extracted text
            TextStamp textStamp = new TextStamp(extractedText)
            {
                // Optional visual settings
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment   = VerticalAlignment.Center,
                Opacity             = 0.7f,
                Background          = false,
                // Position the stamp on the page (example coordinates)
                XIndent = 100,
                YIndent = 500
            };

            // 4. Apply the stamp to the target PDF
            using (Document targetDoc = new Document(targetPdf))
            {
                // Add the stamp to the first page (page index is 1‑based)
                Page firstPage = targetDoc.Pages[1];
                textStamp.Put(firstPage);

                // Save the result
                targetDoc.Save(outputPdf);
            }

            Console.WriteLine($"Stamp applied and saved to '{outputPdf}'.");
        }
    }
}
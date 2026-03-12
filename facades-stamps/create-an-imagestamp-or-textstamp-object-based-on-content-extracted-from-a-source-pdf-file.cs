using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string sourcePdf = "source.pdf";   // PDF to extract content from
        const string targetPdf = "target.pdf";   // PDF to which the stamp will be applied
        const string outputPdf = "output.pdf";   // Resulting PDF

        // Verify that the source PDF exists before proceeding.
        if (!File.Exists(sourcePdf))
        {
            Console.Error.WriteLine($"Source file '{sourcePdf}' not found. Operation aborted.");
            return;
        }

        // -----------------------------------------------------------------
        // 1. Extract the first image from the source PDF using PdfExtractor
        // -----------------------------------------------------------------
        string tempImagePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
        try
        {
            PdfExtractor extractor = new PdfExtractor();
            extractor.BindPdf(sourcePdf);
            extractor.ExtractImage();

            if (extractor.HasNextImage())
            {
                // Save the extracted image to a temporary file. The overload without
                // ImageFormat saves the image in its original format, avoiding the
                // Windows‑only System.Drawing.Imaging.ImageFormat type.
                extractor.GetNextImage(tempImagePath);
            }
            else
            {
                Console.Error.WriteLine("No images found in the source PDF.");
                return;
            }

            // -------------------------------------------------------------
            // 2. Create a Stamp (image stamp) and bind the extracted image
            // -------------------------------------------------------------
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            // BindImage has an overload that accepts a file path, eliminating the need
            // for a FileStream and the System.Drawing namespace.
            stamp.BindImage(tempImagePath);
            stamp.Opacity = 0.5f;          // semi‑transparent
            stamp.IsBackground = true;    // place behind existing content

            // -------------------------------------------------------------
            // 3. Apply the stamp to the target PDF using PdfFileStamp
            // -------------------------------------------------------------
            using (PdfFileStamp fileStamp = new PdfFileStamp())
            {
                fileStamp.BindPdf(targetPdf);   // load the PDF to be stamped
                fileStamp.AddStamp(stamp);      // add the prepared stamp
                fileStamp.Save(outputPdf);      // write the result
                // No explicit Close() required; using‑statement disposes it.
            }

            Console.WriteLine($"Stamped PDF saved to '{outputPdf}'.");
        }
        finally
        {
            // Clean up the temporary image file
            if (File.Exists(tempImagePath))
            {
                try { File.Delete(tempImagePath); } catch { /* ignore */ }
            }
        }
    }
}

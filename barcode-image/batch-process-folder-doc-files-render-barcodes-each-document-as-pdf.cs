using System;
using System.IO;
using Aspose.Words;

namespace BatchDocToPdfWithBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input folder containing .doc files
            string inputFolder = @"C:\InputDocs";
            // Output folder for generated PDFs
            string outputFolder = @"C:\OutputPdfs";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all .doc files in the input folder (non‑recursive)
            string[] docFiles = Directory.GetFiles(inputFolder, "*.doc");

            foreach (string docPath in docFiles)
            {
                // Load the Word document from file
                Document doc = new Document(docPath);

                // Update all fields so that MERGEBARCODE / DISPLAYBARCODE fields are rendered
                doc.UpdateFields();

                // Build the output PDF file name (same base name, .pdf extension)
                string pdfFileName = Path.GetFileNameWithoutExtension(docPath) + ".pdf";
                string pdfPath = Path.Combine(outputFolder, pdfFileName);

                // Save the document as PDF; the format is inferred from the .pdf extension
                doc.Save(pdfPath);
            }
        }
    }
}

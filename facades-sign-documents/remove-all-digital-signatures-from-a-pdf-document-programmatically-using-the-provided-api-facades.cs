using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPath = "input.pdf";
        const string outputPath = "unsigned.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Create the PdfFileSignature facade, bind the PDF, remove signatures, and save.
        using (PdfFileSignature pdfSign = new PdfFileSignature())
        {
            // Load the PDF file into the facade.
            pdfSign.BindPdf(inputPath);

            // Remove all digital signatures from the document.
            pdfSign.RemoveSignatures();

            // Save the unsigned PDF to the specified output path.
            pdfSign.Save(outputPath);
        }

        Console.WriteLine($"All signatures removed. Saved to '{outputPath}'.");
    }
}
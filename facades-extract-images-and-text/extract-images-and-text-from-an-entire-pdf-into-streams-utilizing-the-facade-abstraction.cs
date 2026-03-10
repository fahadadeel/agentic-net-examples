using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string pdfPath = "input.pdf";

        if (!File.Exists(pdfPath))
        {
            Console.Error.WriteLine($"File not found: {pdfPath}");
            return;
        }

        // Streams that will hold extracted content
        List<MemoryStream> imageStreams = new List<MemoryStream>();
        MemoryStream textStream = new MemoryStream();

        // Bind the PDF to PdfExtractor and perform extraction
        using (FileStream pdfFileStream = File.OpenRead(pdfPath))
        using (PdfExtractor extractor = new PdfExtractor())
        {
            // Initialize the facade with the PDF stream
            extractor.BindPdf(pdfFileStream);

            // ----- Extract all text -----
            extractor.ExtractText();                 // Perform text extraction
            extractor.GetText(textStream);           // Save extracted text into a stream
            textStream.Position = 0;                 // Reset for reading later

            // ----- Extract all images -----
            extractor.ExtractImage();                // Perform image extraction
            while (extractor.HasNextImage())
            {
                MemoryStream imgStream = new MemoryStream();
                extractor.GetNextImage(imgStream);   // Retrieve next image into a stream
                imgStream.Position = 0;
                imageStreams.Add(imgStream);
            }
        }

        // Example: output extracted text to console
        using (StreamReader reader = new StreamReader(textStream))
        {
            string allText = reader.ReadToEnd();
            Console.WriteLine("=== Extracted Text ===");
            Console.WriteLine(allText);
        }

        // Example: save each extracted image to a file (optional)
        for (int i = 0; i < imageStreams.Count; i++)
        {
            string imagePath = $"image-{i + 1}.png";
            using (FileStream file = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
            {
                imageStreams[i].CopyTo(file);
            }
            Console.WriteLine($"Saved image {i + 1} to {imagePath}");
        }
    }
}
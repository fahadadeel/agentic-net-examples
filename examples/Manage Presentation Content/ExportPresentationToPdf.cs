using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path to the destination PDF file
        string outputPath = "output.pdf";

        // Load the presentation from the PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create a memory stream to act as a BLOB for the PDF data
        System.IO.MemoryStream pdfBlob = new System.IO.MemoryStream();

        // Save the presentation to the memory stream in PDF format
        presentation.Save(pdfBlob, Aspose.Slides.Export.SaveFormat.Pdf);

        // Write the BLOB content to the output PDF file
        System.IO.File.WriteAllBytes(outputPath, pdfBlob.ToArray());

        // Clean up resources
        pdfBlob.Dispose();
        presentation.Dispose();
    }
}
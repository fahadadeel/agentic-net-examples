using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation file path (e.g., a large PPTX file)
        string inputPath = "input.pptx";
        // Output PPT file path
        string outputPath = "output.ppt";

        // Read the entire presentation file into a byte array (BLOB)
        byte[] presentationData = File.ReadAllBytes(inputPath);

        // Create a PresentationFactory instance
        PresentationFactory factory = new PresentationFactory();

        // Load the presentation from the BLOB
        IPresentation presentation = factory.ReadPresentation(presentationData);

        // Prepare a memory stream to hold the exported PPT data
        MemoryStream outputStream = new MemoryStream();

        // Save the presentation to the stream in PPT format
        presentation.Save(outputStream, SaveFormat.Ppt);

        // Write the stream contents to the output file
        File.WriteAllBytes(outputPath, outputStream.ToArray());

        // Clean up resources
        outputStream.Close();
        presentation.Dispose();
    }
}
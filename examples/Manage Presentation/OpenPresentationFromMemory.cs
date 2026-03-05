using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load PPTX file bytes into memory
        string inputPath = "input.pptx";
        byte[] pptxBytes = File.ReadAllBytes(inputPath);

        // Create a memory stream from the byte array
        using (MemoryStream memoryStream = new MemoryStream(pptxBytes))
        {
            // Open presentation from memory stream
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(memoryStream))
            {
                // Save the presentation to a file
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
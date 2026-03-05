using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InspectPresentationData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = "C:\\Data\\";
            string inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
            string outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all images and display their sizes in bytes
            foreach (Aspose.Slides.IPPImage image in presentation.Images)
            {
                long imageSizeInBytes = (long)image.BinaryData.Length;
                Console.WriteLine("Image size: " + imageSizeInBytes + " bytes");
            }

            // Save the presentation (no changes made, just to satisfy lifecycle rule)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string newImagePath = "newImage.png";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Read the new image data into a byte array
        byte[] newImageData = System.IO.File.ReadAllBytes(newImagePath);

        // Replace the first image in the presentation (if any) with the new image data
        if (pres.Images.Count > 0)
        {
            Aspose.Slides.IPPImage img = pres.Images[0];
            img.ReplaceImage(newImageData);
        }

        // Save the modified presentation in PPTX format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
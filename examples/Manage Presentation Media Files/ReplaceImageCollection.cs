using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string sourcePath = "input.pptx";
        // Path to the new image file that will replace existing images
        string newImagePath = "newImage.png";
        // Path to save the modified presentation
        string outputPath = "output.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Read the new image data into a byte array
            byte[] newImageData = File.ReadAllBytes(newImagePath);

            // Iterate through all images in the presentation and replace them
            int imageCount = presentation.Images.Count;
            for (int i = 0; i < imageCount; i++)
            {
                Aspose.Slides.IPPImage image = presentation.Images[i];
                image.ReplaceImage(newImageData);
            }

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
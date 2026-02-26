using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string sourcePath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
        {
            // Path to the new image that will replace existing images
            string newImagePath = "newImage.png";

            // Read new image data into a byte array
            byte[] newImageData = File.ReadAllBytes(newImagePath);

            // Get the image collection from the presentation
            Aspose.Slides.IImageCollection images = pres.Images;

            // Replace each image in the collection with the new image data
            for (int i = 0; i < images.Count; i++)
            {
                Aspose.Slides.IPPImage img = images[i];
                img.ReplaceImage(newImageData);
            }

            // Save the modified presentation
            string outputPath = "output.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
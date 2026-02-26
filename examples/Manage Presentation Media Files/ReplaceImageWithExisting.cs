using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get the target image that will be replaced (e.g., first image)
            Aspose.Slides.IPPImage targetImage = presentation.Images[0];

            // Get the source image already present in the collection (e.g., second image)
            Aspose.Slides.IPPImage sourceImage = presentation.Images[1];

            // Replace the target image data with the source image
            targetImage.ReplaceImage(sourceImage);

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Effects;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Get the first shape as a picture frame
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes[0] as Aspose.Slides.IPictureFrame;

        if (pictureFrame != null)
        {
            // Retrieve the collection of image transform operations applied to the picture
            Aspose.Slides.Effects.IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

            // Iterate through the operations to inspect transparency-related effects
            foreach (Aspose.Slides.Effects.IImageTransformOperation effect in imageTransform)
            {
                // For demonstration, output the type of each effect
                Console.WriteLine("Effect type: " + effect.GetType().Name);
            }
        }

        // Save the presentation before exiting
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
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

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Retrieve the first picture frame (placeholder) on the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes[0] as Aspose.Slides.IPictureFrame;

        if (pictureFrame != null)
        {
            // Apply a 50% opacity (alpha) using the Alpha Modulate Fixed effect
            pictureFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(50f);
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
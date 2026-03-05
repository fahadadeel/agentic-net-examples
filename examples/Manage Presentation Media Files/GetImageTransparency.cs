using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Assume the first shape is a picture frame
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes[0] as Aspose.Slides.IPictureFrame;

        if (pictureFrame != null)
        {
            // Access the image transform collection
            Aspose.Slides.Effects.IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

            // Iterate through the effects to find AlphaModulateFixed
            foreach (Aspose.Slides.Effects.IImageTransformOperation effect in imageTransform)
            {
                if (effect is Aspose.Slides.Effects.IAlphaModulateFixed)
                {
                    Aspose.Slides.Effects.IAlphaModulateFixed alphaMod = (Aspose.Slides.Effects.IAlphaModulateFixed)effect;

                    // Get effective data to read the current amount (transparency percentage)
                    Aspose.Slides.Effects.IAlphaModulateFixedEffectiveData effectiveData = alphaMod.GetEffective();
                    float amount = effectiveData.Amount;

                    Console.WriteLine("Alpha Modulate Fixed amount (transparency %): " + amount);
                }
            }
        }

        // Save the presentation before exiting
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
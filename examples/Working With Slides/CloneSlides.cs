using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation("source.pptx");

        // Create a new destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the slide collection of the destination presentation
        Aspose.Slides.ISlideCollection destSlides = destPres.Slides;

        // Clone each slide from the source to the destination
        for (int i = 0; i < srcPres.Slides.Count; i++)
        {
            Aspose.Slides.ISlide sourceSlide = srcPres.Slides[i];
            // Insert the cloned slide at the end of the destination collection
            destSlides.InsertClone(destSlides.Count, sourceSlide);
        }

        // Save the cloned presentation
        destPres.Save("cloned_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        srcPres.Dispose();
        destPres.Dispose();
    }
}
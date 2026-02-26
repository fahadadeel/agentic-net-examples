using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation("Source.pptx");

        // Create a new destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the first slide from the source presentation
        Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];

        // Insert a clone of the source slide into the destination presentation at index 0
        Aspose.Slides.ISlideCollection destSlides = destPres.Slides;
        destSlides.InsertClone(0, sourceSlide);

        // Save the destination presentation
        destPres.Save("ClonedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        srcPres.Dispose();
        destPres.Dispose();
    }
}
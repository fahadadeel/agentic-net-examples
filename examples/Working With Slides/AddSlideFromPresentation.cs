using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string sourcePath = "SourcePresentation.pptx";
        // Path for the output PPTX file
        string outputPath = "ResultPresentation.pptx";

        // Load the source presentation
        Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);
        // Create a new empty destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the slide collection of the destination presentation
        Aspose.Slides.ISlideCollection destSlides = destPres.Slides;
        // Clone the first slide from the source presentation into the destination
        destSlides.AddClone(srcPres.Slides[0]);

        // Save the destination presentation
        destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        srcPres.Dispose();
        destPres.Dispose();
    }
}
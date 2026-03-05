using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string sourcePath = "SourcePresentation.pptx";
        string destinationPath = "DestinationPresentation.pptx";

        // Load the source presentation
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath);

        // Create a new (empty) destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the slide collection of the destination presentation
        Aspose.Slides.ISlideCollection destSlides = destPres.Slides;

        // Append each slide from the source presentation to the destination
        for (int index = 0; index < sourcePres.Slides.Count; index++)
        {
            destSlides.AddClone(sourcePres.Slides[index]);
        }

        // Save the destination presentation
        destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePres.Dispose();
        destPres.Dispose();
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation file
        string sourcePath = "source.pptx";
        // Path to the destination presentation file
        string destinationPath = "merged.pptx";

        // Load the source presentation
        Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath);
        // Create a new empty destination presentation
        Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation();

        // Get slide collections from both presentations
        Aspose.Slides.ISlideCollection sourceSlides = sourcePresentation.Slides;
        Aspose.Slides.ISlideCollection destinationSlides = destinationPresentation.Slides;

        // Clone each slide from the source into the destination
        for (int index = 0; index < sourceSlides.Count; index++)
        {
            Aspose.Slides.ISlide sourceSlide = sourceSlides[index];
            destinationSlides.AddClone(sourceSlide);
        }

        // Save the merged presentation
        destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePresentation.Dispose();
        destinationPresentation.Dispose();
    }
}
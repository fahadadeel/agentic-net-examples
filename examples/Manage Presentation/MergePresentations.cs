using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the destination presentation (the one that will receive the merged slides)
        Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation("Destination.pptx");

        // Load the source presentation (the one whose slides will be merged)
        Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("Source.pptx");

        // Iterate through each slide in the source presentation
        for (int slideIndex = 0; slideIndex < sourcePresentation.Slides.Count; slideIndex++)
        {
            // Get the current slide from the source
            Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[slideIndex];

            // Clone the source slide and add it to the end of the destination presentation
            // This operation also copies the layout information associated with the slide
            destinationPresentation.Slides.AddClone(sourceSlide);
        }

        // Save the merged presentation to a new file
        destinationPresentation.Save("MergedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
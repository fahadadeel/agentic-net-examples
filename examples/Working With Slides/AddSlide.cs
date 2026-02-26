using System;
using Aspose.Slides;

namespace SlideCloneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load source presentation containing the slide to be copied
            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("source.pptx");

            // Create a new destination presentation
            Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation();

            // Get the first slide from the source presentation
            Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];

            // Clone the source slide and add it to the destination presentation
            destinationPresentation.Slides.AddClone(sourceSlide);

            // Save the destination presentation
            destinationPresentation.Save("clonedSlide.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose presentations
            sourcePresentation.Dispose();
            destinationPresentation.Dispose();
        }
    }
}
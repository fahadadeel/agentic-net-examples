using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation that will hold the imported slides
            Presentation destinationPresentation = new Presentation();

            // Load the source presentation from which slides will be imported
            Presentation sourcePresentation = new Presentation("Source.pptx");

            // Get the collection of slides from the source presentation
            ISlideCollection sourceSlides = sourcePresentation.Slides;

            // Iterate through each slide in the source and add a clone to the destination
            for (int index = 0; index < sourceSlides.Count; index++)
            {
                ISlide sourceSlide = sourceSlides[index];
                destinationPresentation.Slides.AddClone(sourceSlide);
            }

            // Save the combined presentation to disk
            destinationPresentation.Save("CombinedPresentation.pptx", SaveFormat.Pptx);

            // Clean up resources
            sourcePresentation.Dispose();
            destinationPresentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
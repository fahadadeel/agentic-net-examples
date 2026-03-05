using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation (e.g., PPT format)
        using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("source.ppt"))
        {
            // Create a new presentation that will hold the imported slides in PPTX format
            using (Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation())
            {
                // Remove the default empty slide from the new presentation
                destinationPresentation.Slides.RemoveAt(0);

                // Iterate through each slide in the source presentation and clone it into the destination
                for (int slideIndex = 0; slideIndex < sourcePresentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[slideIndex];
                    destinationPresentation.Slides.AddClone(sourceSlide);
                }

                // Save the combined presentation in PPTX format
                destinationPresentation.Save("merged_output.pptx", SaveFormat.Pptx);
            }
        }
    }
}
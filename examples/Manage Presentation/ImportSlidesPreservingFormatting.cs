using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths to source and destination presentations
        string sourcePath = "source.pptx";
        string destinationPath = "merged.pptx";

        // Load the source presentation
        Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath);
        // Create a new empty destination presentation
        Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation();

        // Import each slide from the source, preserving formatting
        for (int i = 0; i < sourcePresentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[i];
            destinationPresentation.Slides.AddClone(sourceSlide);
        }

        // Save the merged presentation in PPTX format
        destinationPresentation.Save(destinationPath, SaveFormat.Pptx);

        // Clean up resources
        sourcePresentation.Dispose();
        destinationPresentation.Dispose();
    }
}
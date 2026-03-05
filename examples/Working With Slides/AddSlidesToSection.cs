using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";
        // Path to the output PPTX file
        string outputPath = "output.pptx";

        // Load the presentation from the file
        using (Presentation presentation = new Presentation(sourcePath))
        {
            // Get the first layout slide to use for new slides
            ILayoutSlide layoutSlide = presentation.LayoutSlides[0];

            // Add a new empty slide to the presentation
            ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

            // Create a new section that starts with the newly added slide
            ISection newSection = presentation.Sections.AddSection("New Section", newSlide);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
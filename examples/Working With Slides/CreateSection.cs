using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Choose the slide from which the new section will start (e.g., second slide)
            Aspose.Slides.ISlide startSlide = presentation.Slides[1];

            // Add a new section named "New Section"
            Aspose.Slides.ISection newSection = presentation.Sections.AddSection("New Section", startSlide);

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
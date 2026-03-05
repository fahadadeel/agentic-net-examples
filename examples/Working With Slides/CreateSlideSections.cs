using System;

class Program
{
    static void Main()
    {
        // Load an existing presentation (replace with your file path)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access an existing section (index 2) and move it to the first position
        Aspose.Slides.ISection section2 = presentation.Sections[2];
        presentation.Sections.ReorderSectionWithSlides(section2, 0);

        // Remove the first section together with its slides
        Aspose.Slides.ISection section0 = presentation.Sections[0];
        presentation.Sections.RemoveSectionWithSlides(section0);

        // Append an empty section at the end of the collection
        presentation.Sections.AppendEmptySection("Last empty section");

        // Add a new section starting from the first slide
        Aspose.Slides.ISlide slide0 = presentation.Slides[0];
        presentation.Sections.AddSection("New Section", slide0);

        // Rename the first section
        presentation.Sections[0].Name = "Renamed Section";

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
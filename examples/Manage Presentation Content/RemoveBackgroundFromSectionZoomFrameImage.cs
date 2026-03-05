using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Ensure there is at least one section; add a new section if none exist
        if (presentation.Sections.Count == 0)
        {
            presentation.Sections.AddSection("Section 1", presentation.Slides[0]);
        }

        // Add a SectionZoomFrame to the first slide linking to the first section
        Aspose.Slides.ISectionZoomFrame sectionZoom = (Aspose.Slides.ISectionZoomFrame)presentation.Slides[0].Shapes.AddSectionZoomFrame(
            150, // X position
            20,  // Y position
            50,  // Width
            50,  // Height
            presentation.Sections[0] // Target section
        );

        // Remove background from the zoom object's image
        sectionZoom.ShowBackground = false;

        // Save the presentation
        presentation.Save("SectionZoom_NoBackground.pptx", SaveFormat.Pptx);
    }
}
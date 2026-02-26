using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Add additional slides to the presentation
            Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
            Aspose.Slides.ISlide thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Create two sections and associate them with the newly added slides
            Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", secondSlide);
            Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", thirdSlide);

            // Add a Section Zoom frame on the first slide that links to the second section
            Aspose.Slides.ISectionZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddSectionZoomFrame(150f, 20f, 100f, 100f, section2);

            // Set the view zoom percentages for slide view and notes view
            presentation.ViewProperties.SlideViewProperties.Scale = 150;
            presentation.ViewProperties.NotesViewProperties.Scale = 150;

            // Save the modified presentation
            presentation.Save("SectionZoom_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
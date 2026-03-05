using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first (default) slide
        Aspose.Slides.ISlide slide1 = presentation.Slides[0];

        // Add two more empty slides based on the default layout
        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Create two sections and assign starting slides
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide2);
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide3);

        // Add a Section Zoom frame on the first slide that links to the second section
        Aspose.Slides.ISectionZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddSectionZoomFrame(150, 20, 100, 100, section2);

        // Set view zoom percentages for slide view and notes view
        presentation.ViewProperties.SlideViewProperties.Scale = 120;
        presentation.ViewProperties.NotesViewProperties.Scale = 120;

        // Save the presentation to a PPTX file
        presentation.Save("SectionZoom_out.pptx", SaveFormat.Pptx);
    }
}
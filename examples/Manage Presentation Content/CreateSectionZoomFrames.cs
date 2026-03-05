using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a second slide
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Create sections in the presentation
        Aspose.Slides.ISection sectionOne = presentation.Sections.AddSection("Section 1", firstSlide);
        Aspose.Slides.ISection sectionTwo = presentation.Sections.AddSection("Section 2", secondSlide);

        // Add a Section Zoom frame to the first slide linking to the second section
        Aspose.Slides.ISectionZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddSectionZoomFrame(150f, 20f, 100f, 100f, sectionTwo);
        zoomFrame.Name = "MySectionZoom";

        // Save the presentation
        presentation.Save("SectionZoomDemo.pptx", SaveFormat.Pptx);
    }
}
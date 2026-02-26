using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add additional slides
        Aspose.Slides.ISlide slide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
        Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

        // Create sections and associate them with slides
        Aspose.Slides.ISection section1 = pres.Sections.AddSection("Section 1", slide1);
        Aspose.Slides.ISection section2 = pres.Sections.AddSection("Section 2", slide2);

        // Add a Section Zoom frame on the first slide linking to the second section
        Aspose.Slides.ISectionZoomFrame zoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(150f, 20f, 50f, 50f, section2);

        // Save the presentation
        pres.Save("SectionZoomDemo.pptx", SaveFormat.Pptx);
    }
}
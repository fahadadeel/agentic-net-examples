using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a new slide that will belong to the first section
        Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide1.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide1.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.YellowGreen;
        slide1.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

        // Create the first section using the slide
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide1);

        // Add a Section Zoom frame on the first slide that links to the created section
        Aspose.Slides.ISectionZoomFrame sectionZoom = presentation.Slides[0].Shapes.AddSectionZoomFrame(150f, 20f, 50f, 50f, section1);

        // Save the presentation in PPTX format
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SectionZoomDemo.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
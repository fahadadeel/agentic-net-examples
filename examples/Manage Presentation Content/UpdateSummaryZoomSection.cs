using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // First slide – set background and create Section 1
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide);

        // Second slide – set background and create Section 2
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide);

        // Third slide – set background and create Section 3
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
        Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide);

        // Add a Summary Zoom frame on the first slide
        Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150, 20, 500, 250);

        // Add a Summary Zoom Section for Section 2
        Aspose.Slides.ISummaryZoomSectionCollection collection = summaryZoom.SummaryZoomCollection;
        Aspose.Slides.ISummaryZoomSection addedSection = collection.AddSummaryZoomSection(section2);
        addedSection.Title = "Section 2 Title";
        addedSection.Description = "Description for Section 2";

        // Remove the Summary Zoom Section we just added
        collection.RemoveSummaryZoomSection(section2);

        // Save the presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "UpdatedSummaryZoom.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}